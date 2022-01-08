using System.Text.Json.Serialization;

namespace IIAuctionHouse.WebApi.Dtos.PercentageDto
{
    public class PercentageIdDto
    {
        public int Id { get; set; }
        
        [JsonIgnore]
        public int Value { get; set; }
    }
}