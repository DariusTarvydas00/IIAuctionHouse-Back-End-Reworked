using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.WebApi.Dto
{
    public class ForestDto
    {
        public ForestUid ForestUid { get; set; }
        
        public string ForestGroup { get; set; }
        
        public string ForestryEnterprise { get; set; }

        public double GeoLocationX { get; set; }

        public double GeoLocationY { get; set; }
        
        public List<Plot> Plots { get; set; }
    }
}