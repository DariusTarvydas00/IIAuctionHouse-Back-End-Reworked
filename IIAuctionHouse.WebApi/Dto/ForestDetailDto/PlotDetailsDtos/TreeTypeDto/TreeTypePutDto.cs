namespace IIAuctionHouse.WebApi.Dto.ForestDetailDto.PlotDetailsDtos.TreeTypeDto
{
    public class TreeTypePutDto
    {
        public int Id { get; set; }
        public OnlyIdDto TreeTypeIdDto { get; set; }
        public OnlyIdDto PercentageIdDto { get; set; }
    }
}