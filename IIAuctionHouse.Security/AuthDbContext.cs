using IIAuctionHouse.Security.Entities;
using Microsoft.EntityFrameworkCore;

namespace IIAuctionHouse.Security
{
    public class AuthDbContext:DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext>options):base(options)
        {
            
        }
        public DbSet<AuthUserEntity> AuthUsers { get; set; }
    }
}