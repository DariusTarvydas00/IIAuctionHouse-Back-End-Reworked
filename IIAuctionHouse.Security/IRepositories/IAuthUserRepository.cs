using IIAuctionHouse.Security.Models;

namespace IIAuctionHouse.Security.IRepositories
{
    public interface IAuthUserRepository
    {
        User FindUser(string email);
        User RegisterUser(string email, string hashedPassword, string salt, bool isAdmin);
    }
}