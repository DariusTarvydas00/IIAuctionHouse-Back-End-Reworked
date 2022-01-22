using IIAuctionHouse.Core.Models.ForestDetailModels.ForestGroupModels.GroupModels;

namespace IIAuctionHouse.Core.Models.ForestDetailModels.ForestGroupModels
{
    public class ForestGroupSubGroup
    {
        public int Id { get; set; }
        public Group Group { get; set; }
        public SubGroup SubGroup { get; set; }
    }
}