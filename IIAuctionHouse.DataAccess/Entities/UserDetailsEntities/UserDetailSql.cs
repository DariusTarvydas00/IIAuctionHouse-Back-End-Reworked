
namespace IIAuctionHouse.DataAccess.Entities.UserDetailsEntities
{
    public class UserDetailSql
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public AddressSql AddressSql { get; set; }
    }
}