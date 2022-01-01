using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities;
using IIAuctionHouse.DataAccess.Entities.ForestEntities;

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
            
            _ctx.TreeTypeEntities.Add(new TreeTypeEntity()
            {
                Name = "treeType1",
                Percentage = 10
            });
            _ctx.TreeTypeEntities.Add(new TreeTypeEntity()
            {
                Name = "treeType2",
                Percentage = 20
            });
            _ctx.TreeTypeEntities.Add(new TreeTypeEntity()
            {
                Name = "treeType3",
                Percentage = 30
            });
            // _ctx.TreeTypes.Add(new TreeTypeEntity()
            // {
            //     Id = 2,
            //     Name = "dsa",
            //     Percentage = 10
            // });
            // _ctx.Forests.Add(new ForestEntity()
            // {
            //     ForestLocationEntityForeignKey = 1,
            //     TreeGroupEntityForeignKey = 1,
            //     TreeTypeEntityForeignKey = 1
            // });
            // _ctx.Forests.Add(new ForestEntity()
            // {
            //     ForestLocationEntityForeignKey = 2,
            //     TreeGroupEntityForeignKey = 2,
            //     TreeTypeEntityForeignKey = 2
            // });
            _ctx.SaveChanges();
        }

        public void SeedProduction()
        {
            throw new System.NotImplementedException();
        }
    }
}