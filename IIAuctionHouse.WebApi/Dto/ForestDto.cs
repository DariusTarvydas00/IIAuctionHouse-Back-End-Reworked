using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestGroupModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;

namespace IIAuctionHouse.WebApi.Dto
{
    public class ForestDto
    {
        public int Id { get; set; }
        public ForestryEnterprise ForestryEnterprise { get; set; }
        public ForestLocation ForestLocation { get; set; }
        public ForestGroupSubGroup ForestGroup { get; set; }
        public ForestUid ForestUid { get; set; }
    }
}