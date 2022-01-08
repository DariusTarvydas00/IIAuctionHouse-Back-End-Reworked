using Newtonsoft.Json;

namespace IIAuctionHouse.WebApi.Dtos.TreeDto
{
    public class TreeIdDto
    {
        public int Id { get; set; }
        
        [JsonIgnore]
        public string Name { get; set; }
    }
}