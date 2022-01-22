using IIAuctionHouse.Core.Models.UserDetailModels;

namespace IIAuctionHouse.Core.IServices.IUserDetailServices
{
    public interface IAddressService
    {
        Address NewAddress(string country, string city, string streetName, int streetOrHouseNumber);
    }
}