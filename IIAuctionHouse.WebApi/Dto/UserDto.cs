using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;
using IIAuctionHouse.Core.Models.UserDetailModels;

namespace IIAuctionHouse.WebApi.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserDetails UserDetails { get; set; }
        public List<ForestUid> ForestUid { get; set; }
    }
}