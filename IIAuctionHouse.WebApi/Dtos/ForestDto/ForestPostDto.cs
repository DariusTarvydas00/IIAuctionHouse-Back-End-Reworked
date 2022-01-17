using System.Collections.Generic;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.WebApi.Dtos.ForestLocationDto;
using IIAuctionHouse.WebApi.Dtos.ForestUidDtos;

namespace IIAuctionHouse.WebApi.Dtos.ForestDto
{
    public class ForestPostDto
    {
        public ForestryEnterprise ForestryEnterprise { get; set; }
        public ForestGroup ForestGroup { get; set; }
        public ForestLocationPostDto ForestLocationPostDto { get; set; }
        public ForestUidPostDto ForestUidPostDto { get; set; }
        public List<Plot> Plots { get; set; }
    }
}