namespace IIAuctionHouse.Core.Models
{
    public class ForestUid
    {
        public int Id { get; set; }
        public int FirstUid { get; set; }
        public int SecondUid { get; set; }
        public int ThirdUid { get; set; }
        //public User User { get; set; }
        public Forest Forest { get; set; }
    }
}