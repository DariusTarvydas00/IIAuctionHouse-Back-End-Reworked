namespace IIAuctionHouse.WebApi.Dto.ForestDetailDto.ForestUidDto
{
    public class ForestUidPutDto
    {
        public int Id { get; set; }
        public OnlyIdDto ForestFirstUidDto { get; set; }
        public OnlyIdDto ForestSecondUidDto { get; set; }
        public OnlyIdDto ForestThirdUidDto { get; set; }
    }
}