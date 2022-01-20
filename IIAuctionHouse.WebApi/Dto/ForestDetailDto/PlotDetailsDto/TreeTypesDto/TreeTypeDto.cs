namespace IIAuctionHouse.WebApi.Dto.ForestDetailDto.PlotDetailsDto.TreeTypesDto
{
    public abstract class TreeTypeDto
    {
        public int Id { get; set; }
        public TreeDto Tree { get; set; }
        public PercentageDto Percentage { get; set; }
    }
}