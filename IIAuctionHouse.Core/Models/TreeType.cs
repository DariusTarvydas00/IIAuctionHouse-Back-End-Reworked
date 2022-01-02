using System.Collections.Generic;

namespace IIAuctionHouse.Core.Models
{
    public class TreeType
    {
         public int Id { get; set; }
         public string Name { get; set; }
         public Percentage Percentage { get; set; }

        //public List<Plot> Plots { get; set; }
    }
}