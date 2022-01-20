using System.IO;
using IIAuctionHouse.Core.IServices.IForestDetailServices;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Domain.ServiceExceptions;

namespace IIAuctionHouse.Domain.Services.ForestDetailServices
{
    public class ForestLocationService: IForestLocationService
    {
        public ForestLocation NewForestLocation(double geoLocationX, double geoLocationY)
        {
            if (geoLocationX < 1 || geoLocationY < 1 )
                throw new InvalidDataException(ServicesExceptions.InvalidValue);
            return new ForestLocation()
            {
                GeoLocationX = geoLocationX,
                GeoLocationY = geoLocationY
            };
        }
    }
}