namespace IIAuctionHouse.WebApi.Dto
{
    public class BidDto
    {
        public int Id { get; set; }
        public int BidAmount { get; set; }
        public int UserId { get; set; }
        public int ForestId { get; set; }
    }
}