using Accounts;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RistoranteAPI.Repository;
using Serilog;

namespace RistoranteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILogic _ristoBL;
        private readonly IJWTManagerRepository repository;

        public LoginController(ILogic _ristoBL, IJWTManagerRepository repository)//Constructor dependency
        {
            this._ristoBL = _ristoBL;
            this.repository = repository;
        }
        //[AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate([FromQuery]UserAccount user)
        {
            var token = repository.Authenticate(user);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult AddUser([FromQuery] string newUserName, string password)
        {
            UserAccount newUser = new UserAccount();
            newUser.UserName = newUserName;
            newUser.Password = password;
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
        }
    }
}
