using IIAuctionHouse.DataAccess.Entities;

namespace IIAuctionHouse.DataAccess
{
    public class MainDbContextSeeder: IMainDbContextSeeder
    {
        private MainDbContext _ctx;

        public MainDbContextSeeder(MainDbContext ctx)
        {
            _ctx = ctx;
        }

        public void SeedDevelopment()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();
            _ctx.Proprietaries.Add(new ProprietaryEntity()
            {
                ProprietaryIdentificationNumber = "0124/2508:0003"
            });
            _ctx.Proprietaries.Add(new ProprietaryEntity()
            {
                ProprietaryIdentificationNumber = "0111/8708:1003"
            });
            _ctx.SaveChanges();
        }

        public void SeedProduction()
        {
            throw new System.NotImplementedException();
        }
    }
}