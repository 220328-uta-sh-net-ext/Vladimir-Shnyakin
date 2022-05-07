using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Logic;
using Accounts;

namespace RistoranteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RistoranteController : ControllerBase
    {
        private ILogic _ristoBL;

        public RistoranteController(ILogic _ristoBL)//Constructor dependency
        {
            this._ristoBL = _ristoBL;
        }

        [HttpGet("All/Restaurants")]
        [ProducesResponseType(200, Type = typeof(List<Restaurant>))]
        public ActionResult<List<Restaurant>> SeeAllRestaurants()
        {
            var restaurants = _ristoBL.SeeAllRestaurants();
            return Ok(restaurants);
        }

        [HttpGet("SearchbyName")]
        [ProducesResponseType(200, Type = typeof(Restaurant))]
        [ProducesResponseType(404)]
        public ActionResult<Restaurant> SearchRestaurant(string name)
        {
            var restaurant = _ristoBL.SearchRestaurant(name);
            if (restaurant.Count <= 0)
                return NotFound($"Restaurant name containing \"{name}\" doesn't exist");
            return Ok(restaurant);
        }
        [HttpGet("SearchbyType")]
        [ProducesResponseType(200, Type = typeof(Restaurant))]
        [ProducesResponseType(404)]
        public ActionResult<Restaurant> SearchRestaurantType(string cuisine)
        {
            var restaurant = _ristoBL.SearchRestaurantType(cuisine);
            if (restaurant.Count <= 0)
                return NotFound($"Restaurant name containing \"{cuisine}\" doesn't exist");
            return Ok(restaurant);
        }
       
        [HttpGet("All/Users")]
        [ProducesResponseType(200, Type = typeof(List<UserAccount>))]
        public ActionResult<List<UserAccount>> SeeAllUsers()
        {
            var users = _ristoBL.SeeAllUsers();
            return Ok(users);
        }

        [HttpGet("Restaurant/Reviews")]
        [ProducesResponseType(200, Type = typeof(List<Review>))]
        public ActionResult<List<Review>> SeeAllReviews(string restaurantName)
        {
            var reviews = _ristoBL.SeeAllReviews(restaurantName);
           // foreach (Review review in reviews)
            return Ok(reviews);
        }

        [HttpPost("Add/Restaurant")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult AddRestaurant([FromQuery] string restaurantName, string cuisine)
        {
            Restaurant newRestaurant = new Restaurant();
            newRestaurant.RestaurantName = restaurantName;
            newRestaurant.Cuisine = cuisine;
            _ristoBL.AddRestaurant(newRestaurant);
            return CreatedAtAction("SearchRestaurant", newRestaurant);
        }

        [HttpPost("Add/User")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult AddUser([FromQuery] string newUserName, string password)
        {
            UserAccount newUser = new UserAccount();
            newUser.UserName = newUserName;
            newUser.Password = password;
            _ristoBL.AddUser(newUser);
            return CreatedAtAction("SeeAllUsers", newUser);
        }
        [HttpPost("Restaurant/Add/Review")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult AddReview([FromQuery]Review newReview,[FromBody] string Note)
        {
            newReview = new Review();
            string restaurantName = newReview.RestaurantName;
            string userName = newReview.UserName;
            Note = newReview.Note;
            _ristoBL.AddReview(newReview, restaurantName, userName);
            return CreatedAtAction("SeeAllReviews", newReview);
        }
    }
}
