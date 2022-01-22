using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;

namespace IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels
{
    public class ForestUid
    {
        public int Id { get; set; }
        public ForestUidFirst FirstUid { get; set; }
        public ForestUidSecond SecondUid { get; set; }
        public ForestUidThird ThirdUid { get; set; }
    }
}