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
            
            _ctx.ForestLocations.Add(new ForestLocationEntity()
            {
                Id = 1,
                ForestryEnterprise = "Esbjerg",
            });
            
            _ctx.ForestLocations.Add(new ForestLocationEntity()
            {
                Id = 2,
                ForestryEnterprise = "Varde"
            });
            _ctx.TreeGroups.Add(new TreeGroupEntity()
            {
                Id = 1,
                GroupOfTree = "Pinophyta"
            });
            _ctx.TreeGroups.Add(new TreeGroupEntity()
            {
                Id = 2,
                GroupOfTree = "Magnoliophyta"
            });
            _ctx.TreeTypes.Add(new TreeTypeEntity()
            {
                Id = 1,
                TypeOfTree = "Aceraceae"
            });
            _ctx.TreeTypes.Add(new TreeTypeEntity()
            {
                Id = 2,
                TypeOfTree = "Pinaceae"
            });
            _ctx.Forests.Add(new ForestEntity()
            {
                ForestLocationEntityForeignKey = 1,
                TreeGroupEntityForeignKey = 1,
                TreeTypeEntityForeignKey = 1
            });
            _ctx.Forests.Add(new ForestEntity()
            {
                ForestLocationEntityForeignKey = 2,
                TreeGroupEntityForeignKey = 2,
                TreeTypeEntityForeignKey = 2
            });
            _ctx.SaveChanges();
        }

        public void SeedProduction()
        {
            throw new System.NotImplementedException();
        }
    }
}