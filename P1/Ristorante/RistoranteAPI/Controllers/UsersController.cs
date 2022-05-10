using Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RistoranteAPI.Repository;

namespace RistoranteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IJWTManagerRepository repository;
        public UsersController(IJWTManagerRepository repository)
        {
            this.repository = repository;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate([FromQuery]UserAccount user)
        {
            var token = repository.Authenticate(user);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
