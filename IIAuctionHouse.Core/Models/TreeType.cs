using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace IIAuctionHouse.Core.Models
{
    public class TreeType
    {
         public int Id { get; set; }
         public string Name { get; set; }
         public Percentage Percentage { get; set; }

         [JsonIgnore]
         public List<Plot> Plots { get; set; }
    }
}