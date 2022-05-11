using Accounts;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;
using RistoranteAPI.Repository;
using Serilog;

namespace RistoranteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private ILogic _ristoBL;
        //private readonly IJWTManagerRepository repository;

        public AdminController(ILogic _ristoBL, IJWTManagerRepository repository)//Constructor dependency
        {
            this._ristoBL = _ristoBL;
            //this.repository = repository;
        }
        [Authorize(Roles = "admin")]
        [HttpGet("All/Users")]
        [ProducesResponseType(200, Type = typeof(List<UserAccount>))]
        public ActionResult<List<UserAccount>> SeeAllUsers()
        {
            var users = _ristoBL.SeeAllUsers();
            return Ok(users);
        }
        [Authorize(Roles = "admin")]
        [HttpGet("Users/Search")]
        [ProducesResponseType(200, Type = typeof(List<UserAccount>))]
        [ProducesResponseType(404)]
        //[ProducesResponseType(403)]
        public ActionResult<UserAccount> SearchUser(string userName)
        {
            var users = _ristoBL.SearchUser(userName);
            if (users.Count <= 0)
                return NotFound($"UserAccount containing \"{userName}\" doesn't exist");
            return Ok(users);
        }
        [Authorize(Roles = "admin")]
        [HttpPost("Add/Restaurant")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult AddRestaurant([FromQuery] string restaurantName, string cuisine)
        {
            Restaurant newRestaurant = new Restaurant();
            newRestaurant.RestaurantName = restaurantName;
            newRestaurant.Cuisine = cuisine;
            try
            {
                _ristoBL.AddRestaurant(newRestaurant);
                return CreatedAtAction("SearchRestaurant", newRestaurant);
            }
            catch (SqlException ex)
            {
                Log.Error($"SqlException in ADD RESTAURANT method catched: {ex}");
                string exeption = $"Can not add restaurant! Restaurant \"{newRestaurant.RestaurantName}\" already exists.\n";
                return BadRequest(exeption);
            }
        }
    }
}
