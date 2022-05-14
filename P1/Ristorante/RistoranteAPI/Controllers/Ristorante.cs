using Microsoft.AspNetCore.Mvc;
using Models;
using Logic;
using Accounts;
using Microsoft.AspNetCore.Authorization;
using RistoranteAPI.Repository;
using System.Security.Claims;
using Microsoft.Data.SqlClient;
using Serilog;
using Microsoft.Extensions.Caching.Memory;

namespace RistoranteAPI.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    
    public class RistoranteController : ControllerBase
    {
        private ILogic _ristoBL;
        //private readonly IJWTManagerRepository repository;
        private readonly IMemoryCache _memoryCache;
        public RistoranteController(ILogic _ristoBL, IMemoryCache memoryCache )//IJWTManagerRepository repository)//Constructor dependency
        {
            this._ristoBL = _ristoBL;
            _memoryCache = memoryCache;
            //this.repository = repository;
        }
        
        [HttpGet("All/Restaurants")]
        [ProducesResponseType(200, Type = typeof(List<Restaurant>))]
        public ActionResult<List<Restaurant>> SeeAllRestaurants()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var restaurants = _ristoBL.SeeAllRestaurants();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Log.Information("It took " + elapsedMs + "ms to read from DB, using \"SeeAllRestaurants\" method");
            return Ok(restaurants);
        }
        /// <summary>
        /// Asynchronous method to get list of all restaurants. Cashes the result for 1 minute
        /// </summary>
        /// <returns>List of all restaurants</returns>
        [HttpGet("All/RestaurantsAsync")]
        [ProducesResponseType(200, Type = typeof(List<Restaurant>))]
        public async Task<ActionResult<List<Restaurant>>> SeeAllRestaurantsAsync()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            if (!_memoryCache.TryGetValue("restaurantsList", out List<Restaurant> restaurants))
            {
                try
                {
                    Log.Information("Restaurant list was cached");
                    restaurants = await _ristoBL.SeeAllRestaurantsAsync();
                    _memoryCache.Set("restaurantsList", restaurants, new TimeSpan(0, 1, 0));
                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    Log.Information("It took " + elapsedMs + "ms to read from DB, using \"SeeAllRestaurantsAsync\" method");
                    return Ok(restaurants);
                }
                catch (SqlException ex)
                {
                    Log.Error($"SqlException catched in SeeAllRestaurantsAsync method: {ex}");
                    return StatusCode(StatusCodes.Status503ServiceUnavailable,"Connection problem detected");
                }
            }
            Log.Information("It took 0ms to read from DB, because it was saved in memory cache");
            return Ok(restaurants);
        }

        [HttpGet("SearchbyName")]
        [ProducesResponseType(200, Type = typeof(Restaurant))]
        [ProducesResponseType(404)]
        public ActionResult<Restaurant> SearchRestaurant(string name)
        {
            var restaurant = _ristoBL.SearchRestaurant(name);
            Log.Information($"{name} was typed to search a restaurant by name");
            if (restaurant.Count <= 0)
                return NotFound($"Restaurant name containing \"{name}\" does not exist");
            return Ok(restaurant);
        }
        /// <summary>
        /// Asynchronous method to search restaurant by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("SearchbyNameAsync")]
        [ProducesResponseType(200, Type = typeof(Restaurant))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Restaurant>> SearchRestaurantAsync(string name)
        {
            var restaurant = await _ristoBL.SearchRestaurantAsync(name);
            Log.Information($"{name} was typed to search a restaurant by name");
            if (restaurant.Count <= 0)
                return NotFound($"Restaurant name containing \"{name}\" does not exist");
            return Ok(restaurant);
        }
        [HttpGet("SearchbyType")]
        [ProducesResponseType(200, Type = typeof(Restaurant))]
        [ProducesResponseType(404)]
        public ActionResult<Restaurant> SearchRestaurantType(string cuisine)
        {
            var restaurant = _ristoBL.SearchRestaurantType(cuisine);
            Log.Information($"{cuisine} was typed to search a restaurant by cuisine");
            if (restaurant.Count <= 0)
                return NotFound($"Restaurant type containing \"{cuisine}\" does not exist");
            return Ok(restaurant);
        }
        [HttpGet("Restaurant/Reviews")]
        [ProducesResponseType(200, Type = typeof(List<Review>))]
        public ActionResult<List<Review>> SeeAllReviews(string restaurantName)
        {
            var reviews = _ristoBL.SeeAllReviews(restaurantName);
            if (reviews.Count <= 0)
                return NotFound($"Restaurant name containing \"{restaurantName}\" does not exist");
            // foreach (Review review in reviews)
            return Ok(reviews);
        }
        /// <summary>
        /// Adds review to the restaurant, chosen by passing it's exact name. User must be authorized first. Username is taken from
        /// ClaimsPrincipal
        /// </summary>
        /// <param name="restaurantName"></param>
        /// <param name="taste"></param>
        /// <param name="mood"></param>
        /// <param name="service"></param>
        /// <param name="price"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("Restaurant/Add/Review")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult AddReview([FromQuery]string restaurantName, double taste, double mood, double service, double price, string? note)
        {
            var userId = User.Identity.Name;
          
            Review newReview = new Review();
         
            newReview.UserName = userId;
            newReview.StarsTaste = taste;
            newReview.StarsMood = mood;
            newReview.StarsService = service;
            newReview.StarsPrice = price;
            newReview.RestaurantName = restaurantName;
            newReview.Note = note;
            if (newReview.Note == null)
                newReview.Note = "";

            try
            {
                _ristoBL.AddReview(newReview);
                return CreatedAtAction("SeeAllReviews", newReview);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Log.Error($"ArgumentOutOfRangeException catched in ADD REVIEW method");
                //string exeption = $"User \"{newReview.UserName}\" cannot add another review to \"{newReview.RestaurantName}\" restaurant.\n";
                return BadRequest("ArgumentOutOfRangeException: Please rate from 1 to 5 only");
            }
            catch(SqlException ex)
            {
                Log.Error($"SqlException catched in ADD REVIEW method: {ex}");
                string exception = ex.ToString();
                if (exception.Contains("PRIMARY"))
                    exception = $"User \"{newReview.UserName}\" cannot add another review to \"{newReview.RestaurantName}\" restaurant.\n";
                else if (exception.Contains("Note"))
                    exception = "Note cannot be more than 140 characters!";
                else
                    exception = $"User \"{newReview.UserName}\" cannot add review to \"{newReview.RestaurantName}\" restaurant.\n";
                return BadRequest(exception);
            } 
        }
    }
}
