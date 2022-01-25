using IIAuctionHouse.Security.Models;

namespace IIAuctionHouse.Security.IServices
{
    public interface IAuthUserService
    {
        User GetUser(string email);
        User RegisterUser(string email, string hashedPasswordFromPlain, string salt, bool isAdmin);
    }
}