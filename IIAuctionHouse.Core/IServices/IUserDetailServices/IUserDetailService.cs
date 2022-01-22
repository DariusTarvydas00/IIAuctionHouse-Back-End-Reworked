using IIAuctionHouse.Core.Models.UserDetailModels;

namespace IIAuctionHouse.Core.IServices.IUserDetailServices
{
    public interface IUserDetailService
    {
        UserDetails NewUserDetails(string email, int phoneNumber, Address address);
    }
}