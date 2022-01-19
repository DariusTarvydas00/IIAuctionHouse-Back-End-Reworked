using System.Collections.Generic;

namespace IIAuctionHouse.Core.Models.ForestDetailModels
{
    public class ForestryEnterprise
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Forest> Forests { get; set; }
    }
}