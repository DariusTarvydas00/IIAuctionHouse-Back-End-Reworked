namespace IIAuctionHouse.Core.Models.Forest
{
    public class Forest
    {
        public int Id { get; set; }

        public TreeGroup TreeGroup { get; set; }

        public TreeType TreeType { get; set; }

        public ForestLocation ForestLocation { get; set; }
    }
}