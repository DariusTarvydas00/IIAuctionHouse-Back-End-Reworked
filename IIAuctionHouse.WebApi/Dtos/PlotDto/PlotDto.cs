namespace IIAuctionHouse.WebApi.Dtos.PlotDto
{
    public class PlotDto
    {
        public double PlotSize { get; set; }
        public string PlotResolution { get; set; }
        public double PlotTenderness { get; set; }
        public int Volume { get; set; }
        public int AverageTreeHeight { get; set; }
        public TreeTypeDto TreeTypeDto { get; set; }
    }
}