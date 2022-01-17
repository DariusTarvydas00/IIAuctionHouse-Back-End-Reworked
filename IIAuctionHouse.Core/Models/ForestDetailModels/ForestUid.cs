using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;

namespace IIAuctionHouse.Core.Models.ForestDetailModels
{
    public class ForestUid
    {
        public int Id { get; set; }
        public ForestUidFirst FirstUid { get; set; }
        public ForestUidSecond SecondUid { get; set; }
        public ForestUidThird ThirdUid { get; set; }

        //public Forest Forest { get; set; }
    }
}