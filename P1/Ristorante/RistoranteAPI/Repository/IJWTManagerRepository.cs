using Accounts;
using Models;

namespace RistoranteAPI.Repository
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(UserAccount user);
    }
}
