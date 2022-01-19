using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;

namespace IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestUidRepositories
{
    public interface IForestUidRepository
    {
         ForestUid GetForestUid(int forestUid);
         ForestUidFirst GetForestUidFirst(int id);
         ForestUidSecond GetForestUidSecond(int id);
         ForestUidThird GetForestUidThird(int id);
    }
}