namespace IIAuctionHouse.WebApi.Dto.BidDto
{
    public class BidPutDto
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public OnlyIdDto UserPostIdDto { get; set; }
        public OnlyIdDto ForestPostIdDto { get; set; }
    }
}