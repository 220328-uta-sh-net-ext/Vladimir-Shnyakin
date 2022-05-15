using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Accounts;
using Microsoft.IdentityModel.Tokens;
using Models;
using Logic;
using Serilog;

namespace RistoranteAPI.Repository
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        private readonly ILogic _logic;
        private readonly IConfiguration _configuration;
        public JWTManagerRepository(IConfiguration configuration, ILogic logic)
        {
            _configuration = configuration;
            _logic = logic;
        }
        /*Dictionary<string, string> UserRecords = new Dictionary<string, string>
        {
            {"user1" , "password1" }
        };*/
        /// <summary>
        /// ClaimTypes will hold authenticated username and role (for admin purposes only)
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Tokens Authenticate(UserAccount user)
        {
           // List<UserAccount> users = logic.SeeAllUsers();
            //if (!users.Exists(a=>a.UserName==user.UserName && a.Password == user.Password))
            if (_logic.AuthenticateUser(user) == false)
                return null;
            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Role, Convert.ToString(user.UserName))
                    }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenhandler.CreateToken(tokenDescriptor);
            Log.Information($"Token for user \"{user.UserName}\" was created");
            return new Tokens { Token = tokenhandler.WriteToken(token) };
        }
    }
}
