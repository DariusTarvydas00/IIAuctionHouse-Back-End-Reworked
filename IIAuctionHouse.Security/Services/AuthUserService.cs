using IIAuctionHouse.Security.IRepositories;
using IIAuctionHouse.Security.IServices;
using IIAuctionHouse.Security.Models;

namespace IIAuctionHouse.Security.Services
{
    public class AuthUserService :IAuthUserService
    {
        private readonly IAuthUserRepository _authUserRepository;

        public AuthUserService(IAuthUserRepository authUserRepository)
        {
            _authUserRepository = authUserRepository;
        }
        public User GetUser(string email)
        {
            return _authUserRepository.FindUser(email);
        }

        public User RegisterUser(string email, string hashedPassword, string salt, bool isAdmin)
        {
            return _authUserRepository.RegisterUser(email, hashedPassword, salt,isAdmin);
        }
    }
}