using IIAuctionHouse.Core.Models.UserDetailModels;

namespace IIAuctionHouse.Core.IServices.IForestDetailServices.IUserDetailServices
{
    public interface IAddressService
    {
        Address NewAddress(string country, string city, string streetName, int streetOrHouseNumber);
    }
}