using IIAuctionHouse.Core.Models.ForestDetailModels.TreeTypes.TTModels;

namespace IIAuctionHouse.Core.Models.ForestDetailModels.TreeTypes
{
    public class TreeType
    {
        public int Id { get; set; }
        public Tree Tree { get; set; }
        public Percentage Percentage { get; set; }
    }
}