using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IIAuctionHouse.WebApi.Dtos
{
    public class Tttdto
    {
        public int Id { get; set; }
        public double PlotSize { get; set; }
        public string PlotResolution { get; set; }
        public double PlotTenderness { get; set; }
        public int Volume { get; set; }
        public int AverageTreeHeight { get; set; }
        public AsdfgDto TreeTypeDto { get; set; }
    }
}