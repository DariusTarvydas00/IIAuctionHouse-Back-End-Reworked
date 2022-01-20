using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;

namespace IIAuctionHouse.Core.IServices.IForestDetailServices.IForestUidServices
{
    public interface IForestUidService
    {
        ForestUid NewForestUid(int firstUid, int secondUid, int thirdUid);
        ForestUid UpdateForestUid(int id, int firstUid, int secondUid, int thirdUid);
    }
}