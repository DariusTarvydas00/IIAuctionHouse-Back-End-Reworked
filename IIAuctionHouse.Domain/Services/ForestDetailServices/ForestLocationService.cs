using IIAuctionHouse.Core.IServices.IForestDetailServices;
using IIAuctionHouse.Core.Models.ForestDetailModels;

namespace IIAuctionHouse.Domain.Services.ForestDetailServices
{
    public class ForestLocationService: IForestLocationService
    {
        public ForestLocation NewForestLocation(double geoLocationX, double geoLocationY)
        {
            return new ForestLocation()
            {
                GeoLocationX = geoLocationX,
                GeoLocationY = geoLocationY
            };
        }
    }
}