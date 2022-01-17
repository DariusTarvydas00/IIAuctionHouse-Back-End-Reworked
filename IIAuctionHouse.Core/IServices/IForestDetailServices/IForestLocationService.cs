using IIAuctionHouse.Core.Models.ForestDetailModels;

namespace IIAuctionHouse.Core.IServices.IForestDetailServices
{
    public interface IForestLocationService
    {
        ForestLocation NewForestLocation(double geoLocationX, double geoLocationY);
    }
}