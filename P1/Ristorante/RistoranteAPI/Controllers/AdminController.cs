﻿using Accounts;
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
    /// <summary>
    /// Holds Admin tools
    /// </summary>
    [ApiController]
    //[Produces("application/json")]
    public class AdminController : ControllerBase
    {
        private ILogic _ristoBL;
        //private readonly IJWTManagerRepository repository;
        /// <summary>
        /// Holds Admin tools
        /// </summary>
        public AdminController(ILogic _ristoBL, IJWTManagerRepository repository)//Constructor dependency
        {
            this._ristoBL = _ristoBL;
            //this.repository = repository;
        }
        /// <summary>
        /// See all registered users
        /// </summary>
        /// <returns>List of UserAccount objects</returns>
        [Authorize(Roles = "admin")]
        [HttpGet("All/Users")]
        [ProducesResponseType(200, Type = typeof(List<UserAccount>))]
        public ActionResult<List<UserAccount>> SeeAllUsers()
        {
            var users = _ristoBL.SeeAllUsers();
            return Ok(users);
        }
        /// <summary>
        /// Pass a string. All user accounts containing it will be displayed
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
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
        /// <summary>
        /// No restaurant with the same name allowed
        /// </summary>
        /// <param name="restaurantName"></param>
        /// <param name="cuisine"></param>
        /// <returns></returns>
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
                Log.Information($"Restaurant named \"{newRestaurant.RestaurantName}\" was added");
                return CreatedAtAction("AddRestaurant", newRestaurant);
            }
            catch (ArgumentException ex)
            {
                Log.Error($"ArgumentException in ADD RESTAURANT method catched: {ex}");
                string exception = ex.Message;
                return BadRequest(exception);
            }
            catch (SqlException ex)
            {
                Log.Error($"SqlException in ADD RESTAURANT method catched: {ex}");
                string exception = $"Can not add restaurant! Restaurant \"{newRestaurant.RestaurantName}\" already exists.\n";
                return BadRequest(exception);
            }
        }
        /// <summary>
        /// Restaurant name must be matched exactly. It's reviews will be removed as well
        /// </summary>
        /// <param name="restauranrName"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpDelete("Remove/Restaurant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult RemoveRestaurant([FromQuery] string restauranrName)
        {
            try
            {
                if (_ristoBL.RemoveRestaurant(restauranrName) == true)
                    return Ok($"Restaurant \"{restauranrName}\" deleted!");
                else
                    return BadRequest("No such restaurant!");
            }
            catch(SqlException ex)
            {
                Log.Error($"SqlException in REMOVE RESTAURANT method catched: {ex}");
                string exception = $"Can not remove restaurant! Restaurant \"{restauranrName}\" does not exist.\n";
                return BadRequest(exception);
            }
        }
        /// <summary>
        /// Delete UserAccount. Reviews by that user are intact
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpDelete("Remove/User")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult RemoveUser([FromQuery] string userName)
        {
            try
            {
                if (_ristoBL.RemoveUser(userName) == true)
                    return Ok($"User \"{userName}\" deleted!");
                else
                    return BadRequest("No such user!");
            }
            catch (SqlException ex)
            {
                Log.Error($"SqlException in REMOVE USER method catched: {ex}");
                string exception = $"Can not remove user! User \"{userName}\" does not exist.\n";
                return BadRequest(exception);
            }
        }
        /// <summary>
        /// Restaurant and user names must be matched exactly
        /// </summary>
        /// <param name="restaurantName"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpDelete("Remove/Review")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult RemoveReview([FromQuery] string restaurantName, string userName)
        {
            try
            {
                if (_ristoBL.RemoveReview(restaurantName, userName) == true)
                    return Ok($"Review by \"{userName}\" for \"{restaurantName}\" was deleted!");
                else
                    return BadRequest("No such review!");
            }
            catch (SqlException ex)
            {
                Log.Error($"SqlException in REMOVE REVIEW method catched: {ex}");
                string exception = $"Can not remove review! User \"{userName}\" did not leave a review for \"{restaurantName}\".\n";
                return BadRequest(exception);
            }
        }
    }
}
