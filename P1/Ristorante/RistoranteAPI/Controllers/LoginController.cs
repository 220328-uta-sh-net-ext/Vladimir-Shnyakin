using System.ComponentModel.DataAnnotations;
using System.Data;
using Accounts;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using RistoranteAPI.Repository;
using Serilog;

namespace RistoranteAPI.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogic _ristoBL;
        private readonly IJWTManagerRepository repository;

        public LoginController(ILogic _ristoBL, IJWTManagerRepository repository)//Constructor dependency
        {
            this._ristoBL = _ristoBL;
            this.repository = repository;
        }
        /// <summary>
        /// Gives token authentication to registered user. Token is good for 5 minutes
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <remarks>Copy the token. Press authorize. Using keyboard type: Bearer /paste token/</remarks>
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate([FromQuery, BindRequired] string UserName, [BindRequired, DataType(DataType.Password)] string password)
        {
            UserAccount user = new()
            {
                UserName = UserName,
                Password = password
            };
            var token = repository.Authenticate(user);
            if (token == null)
                return BadRequest("Wrong credentials. Please make sure you entered correct" +
                    " username and password.");
            return Ok(token);
        }
        /// <summary>
        /// Registers new user
        /// </summary>
        /// <param name="newUserName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult AddUser([FromQuery, BindRequired] string newUserName, [BindRequired, DataType(DataType.Password)] string password)
        {
            UserAccount newUser = new()
            {
                UserName = newUserName,
                Password = password
            };
            try
            {
                _ristoBL.AddUser(newUser);
                return CreatedAtAction("AddUser", newUser);
            }
            catch(SqlException ex)
            {
                Log.Error($"SqlException in ADD USER method catched: {ex}");
                string exeption = $"Can not add user! {newUser.UserName} is taken.\n";
                return BadRequest(exeption);
            }
            catch (DuplicateNameException ex)
            {
                Log.Error($"SqlException in ADD USER method catched: {ex}");
                return BadRequest(ex.Message);
            }
        }
        /*[Authorize]
        [HttpPut]
        [Route("ChangeMyCredentials")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult ChangeUser([FromQuery] string newUserName, string newPassword)
        {
            var userId = User.Identity.Name;
            UserAccount newUser = new UserAccount();
            newUser.UserName = newUserName;
            newUser.Password = newPassword;
            try
            {
                _ristoBL.ChangeUser(newUser, userId);
                return CreatedAtAction("ChangeUser", newUser);
            }
            catch (System.Data.DuplicateNameException ex)
            {
                Log.Error($"DuplicateNameException in CHANGE USER method catched: {ex}");
                string exeption = $"Please choose another user name!\n";
                return BadRequest(exeption);
            }
            catch (SqlException ex)
            {
                Log.Error($"SqlException in CHANGE USER method catched: {ex}");
                string exeption = $"User name\"{newUser.UserName}\" is taken!";
                return BadRequest(exeption);
            }
        }*/
    }
}
