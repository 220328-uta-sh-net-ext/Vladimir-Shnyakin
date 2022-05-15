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
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RistoranteAPI.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    
    public class RistoranteController : ControllerBase
    {
        private readonly ILogic _ristoBL;
        //private readonly IJWTManagerRepository repository;
        private readonly IMemoryCache _memoryCache;
        public RistoranteController(ILogic _ristoBL, IMemoryCache memoryCache )//IJWTManagerRepository repository)//Constructor dependency
        {
            this._ristoBL = _ristoBL;
            _memoryCache = memoryCache;
            //this.repository = repository;
        }
        /// <summary>
        /// Standard method. No cache. Logs time of execution in log file
        /// </summary>
        /// <returns></returns>
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
        /// Asynchronous method to get list of all restaurants. Cashes the result for 1 minute.
        /// Logs time of execution in log file
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
        /// <summary>
        /// Simple search using "contains"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("SearchbyName")]
        [ProducesResponseType(200, Type = typeof(Restaurant))]
        [ProducesResponseType(404)]
        public ActionResult<Restaurant> SearchRestaurant([BindRequired]string name)
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
        public async Task<ActionResult<Restaurant>> SearchRestaurantAsync([BindRequired] string name)
        {
            var restaurant = await _ristoBL.SearchRestaurantAsync(name);
            Log.Information($"{name} was typed to search a restaurant by name");
            if (restaurant.Count <= 0)
                return NotFound($"Restaurant name containing \"{name}\" does not exist");
            return Ok(restaurant);
        }
        /// <summary>
        /// Simple search using "contains"
        /// </summary>
        /// <param name="cuisine"></param>
        /// <returns></returns>
        [HttpGet("SearchbyType")]
        [ProducesResponseType(200, Type = typeof(Restaurant))]
        [ProducesResponseType(404)]
        public ActionResult<Restaurant> SearchRestaurantType([BindRequired] string cuisine)
        {
            var restaurant = _ristoBL.SearchRestaurantType(cuisine);
            Log.Information($"{cuisine} was typed to search a restaurant by cuisine");
            if (restaurant.Count <= 0)
                return NotFound($"Restaurant type containing \"{cuisine}\" does not exist");
            return Ok(restaurant);
        }
        /// <summary>
        /// Shows all reviews with restaurant names that contain given string
        /// </summary>
        /// <param name="restaurantName"></param>
        /// <returns></returns>
        /// <remarks>Pass a string</remarks>
        [HttpGet("Restaurant/Reviews")]
        [ProducesResponseType(200, Type = typeof(List<Review>))]
        public ActionResult<List<Review>> SeeAllReviews([BindRequired] string restaurantName)
        {
            var reviews = _ristoBL.SeeAllReviews(restaurantName);
            if (reviews.Count <= 0)
                return NotFound($"Restaurant name containing \"{restaurantName}\" does not exist");
            // foreach (Review review in reviews)
            return Ok(reviews);
        }
        /// <summary>
        /// Adds review to the restaurant, chosen by passing it's exact name. User must be authorized first
        /// </summary>
        /// <param name="restaurantName"></param>
        /// <param name="taste"></param>
        /// <param name="mood"></param>
        /// <param name="service"></param>
        /// <param name="price"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        /// <remarks>Username is taken from ClaimsPrincipal</remarks>
        [Authorize]
        [HttpPost("Restaurant/AddReview")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult AddReview([FromQuery, BindRequired]string restaurantName, [BindRequired] double taste, 
            [BindRequired] double mood, [BindRequired] double service, [BindRequired] double price, string? note)
        {
            var userId = User.Identity.Name;

            Review newReview = new()
            {
                UserName = userId,
                StarsTaste = taste,
                StarsMood = mood,
                StarsService = service,
                StarsPrice = price,
                RestaurantName = restaurantName,
                Note = note
            };
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
        /// <summary>
        /// Remove review that you left. You can only have 1 review per restaurant. Restaurant name must be matched exactly
        /// </summary>
        /// <param name="restaurantName"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("Restaurant/RemoveMyReview")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult RemoveReview([FromQuery, BindRequired] string restaurantName)
        {
            var userId = User.Identity.Name;
            try
            {
                if (_ristoBL.RemoveReview(restaurantName, userId) == true)
                    return Ok($"Your review for \"{restaurantName}\" was deleted!");
                else
                    return BadRequest($"You did not leave a review for \"{restaurantName}\".\n");
            }
            catch (SqlException ex)
            {
                Log.Error($"SqlException in REMOVE REVIEW method catched: {ex}");
                string exception = $"Something went wrong";
                return BadRequest(exception);
            }
        }
        /// <summary>
        /// Edit your review after you have submitted it. Restaurant name must be matched exactly
        /// </summary>
        /// <param name="restaurantName"></param>
        /// <param name="taste"></param>
        /// <param name="mood"></param>
        /// <param name="service"></param>
        /// <param name="price"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("Restaurant/ChangeMyReview")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult ChangeReview([FromQuery, BindRequired] string restaurantName, [BindRequired] double taste,
            [BindRequired] double mood, [BindRequired] double service, [BindRequired] double price, string? note)
        {
            var userId = User.Identity.Name;

            Review newReview = new()
            {
                UserName = userId,
                StarsTaste = taste,
                StarsMood = mood,
                StarsService = service,
                StarsPrice = price,
                RestaurantName = restaurantName,
                Note = note
            };
            if (newReview.Note == null)
                newReview.Note = "";

            try
            {
                _ristoBL.ChangeReview(newReview);
                return CreatedAtAction("SeeAllReviews", newReview);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Log.Error($"ArgumentOutOfRangeException catched in CHANGE REVIEW method");
                //string exeption = $"User \"{newReview.UserName}\" cannot add another review to \"{newReview.RestaurantName}\" restaurant.\n";
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Log.Error($"ArgumentException catched in CHANGE REVIEW method");
                return BadRequest(ex.Message);
            }
            catch (SqlException ex)
            {
                Log.Error($"SqlException catched in CHANGE REVIEW method: {ex}");
                string exception = ex.ToString();
                if (exception.Contains("PRIMARY"))
                    exception = $"User \"{newReview.UserName}\" cannot add another review to \"{newReview.RestaurantName}\" restaurant.\n";
                else if (exception.Contains("Note"))
                    exception = "Note cannot be more than 140 characters!";
                else
                    exception = $"User \"{newReview.UserName}\" cannot change review to \"{newReview.RestaurantName}\" restaurant.\n";
                return BadRequest(exception);
            }
        }
    }
}
