using System.IO;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IForestUidServices;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;
using IIAuctionHouse.Domain.ServiceExceptions;

namespace IIAuctionHouse.Domain.Services.ForestDetailServices.ForestUidServices
{
    public class ForestUidService: IForestUidService
    {
        public ForestUid NewForestUid(int firstUid, int secondUid, int thirdUid)
        {
            if (firstUid < 1 || secondUid < 1 || thirdUid < 1)
                throw new InvalidDataException(ServicesExceptions.InvalidValue);
            return new ForestUid()
            {
                FirstUid = new ForestUidFirst()
                {
                    Id = firstUid
                },
                SecondUid = new ForestUidSecond()
                {
                    Id = secondUid
                },
                ThirdUid = new ForestUidThird()
                {
                    Id = thirdUid
                }
            };
        }

        public ForestUid UpdateForestUid(int id, int firstUid, int secondUid, int thirdUid)
        {
            if (firstUid < 1 || secondUid < 1 || thirdUid < 1 || id < 1)
                throw new InvalidDataException(ServicesExceptions.InvalidValue);
            return new ForestUid()
            {
                Id = id,
                FirstUid = new ForestUidFirst()
                {
                    Id = firstUid
                },
                SecondUid = new ForestUidSecond()
                {
                    Id = secondUid
                },
                ThirdUid = new ForestUidThird()
                {
                    Id = thirdUid
                }
            };
        }
    }
}