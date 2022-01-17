using IIAuctionHouse.Core.IServices.IForestDetailServices.IForestUidServices;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;

namespace IIAuctionHouse.Domain.Services.ForestDetailServices.ForestUidServices
{
    public class ForestUidService: IForestUidService
    {
        public ForestUid NewForestUid(int firstUid, int secondUid, int thirdUid)
        {
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