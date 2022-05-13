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
            this._memoryCache = memoryCache;
            //this.repository = repository;
        }
        
        [HttpGet("All/Restaurants")]
        [ProducesResponseType(200, Type = typeof(List<Restaurant>))]
        public ActionResult<List<Restaurant>> SeeAllRestaurants()
        {
            var restaurants = _ristoBL.SeeAllRestaurants();
            return Ok(restaurants);
        }
        [HttpGet("All/RestaurantsAsync")]
        [ProducesResponseType(200, Type = typeof(List<Restaurant>))]
        public async Task<ActionResult<List<Restaurant>>> SeeAllRestaurantsAsync()
        {
            if (!_memoryCache.TryGetValue("restaurantsList", out List<Restaurant> restaurants))
            {
                restaurants = await _ristoBL.SeeAllRestaurantsAsync();
                _memoryCache.Set("restaurantsList", restaurants, new TimeSpan(0, 1, 0));
            }
            return Ok(restaurants);
        }

        [HttpGet("SearchbyName")]
        [ProducesResponseType(200, Type = typeof(Restaurant))]
        [ProducesResponseType(404)]
        public ActionResult<Restaurant> SearchRestaurant(string name)
        {
            var restaurant = _ristoBL.SearchRestaurant(name);
            if (restaurant.Count <= 0)
                return NotFound($"Restaurant name containing \"{name}\" does not exist");
            return Ok(restaurant);
        }
        [HttpGet("SearchbyNameAsync")]
        [ProducesResponseType(200, Type = typeof(Restaurant))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Restaurant>> SearchRestaurantAsync(string name)
        {
            var restaurant = await _ristoBL.SearchRestaurantAsync(name);
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
