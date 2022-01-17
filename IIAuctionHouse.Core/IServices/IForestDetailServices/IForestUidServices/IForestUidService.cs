using IIAuctionHouse.Core.Models.ForestDetailModels;

namespace IIAuctionHouse.Core.IServices.IForestDetailServices.IForestUidServices
{
    public interface IForestUidService
    {
        ForestUid NewForestUid(int firstUid, int secondUid, int thirdUid);
        ForestUid UpdateForestUid(int id, int firstUid, int secondUid, int thirdUid);
    }
}