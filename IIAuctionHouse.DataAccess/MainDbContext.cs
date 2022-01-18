using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;
using IIAuctionHouse.Core.Models.UserDetailModels;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestUidEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.PlotEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.PlotEntities.TreeTypeEntities;
using Microsoft.EntityFrameworkCore;

namespace IIAuctionHouse.DataAccess
{
    public class MainDbContext: DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Exclude Migrations
            
            modelBuilder.Entity<TreeType>().ToTable(nameof(TreeType), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<Tree>().ToTable(nameof(Tree), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<Percentage>().ToTable(nameof(Percentage), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<ForestUid>().ToTable(nameof(ForestUid), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<ForestUidFirst>().ToTable(nameof(ForestUidFirst), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<ForestUidSecond>().ToTable(nameof(ForestUidSecond), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<ForestUidThird>().ToTable(nameof(ForestUidThird), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<Plot>().ToTable(nameof(Plot), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<Forest>().ToTable(nameof(Forest), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<ForestLocation>().ToTable(nameof(ForestLocation), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<ForestGroup>().ToTable(nameof(ForestGroup), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<ForestryEnterprise>().ToTable(nameof(ForestryEnterprise), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<Bid>().ToTable(nameof(Bid), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<User>().ToTable(nameof(User), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<Admin>().ToTable(nameof(Admin), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<Address>().ToTable(nameof(Address), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<UserDetails>().ToTable(nameof(UserDetails), t => t.ExcludeFromMigrations());

            #endregion

            #region RelationShips

            modelBuilder.Entity<ForestUid>().HasOne(first => first.FirstUid).WithMany();
            modelBuilder.Entity<ForestUid>().HasOne(second => second.SecondUid).WithMany();
            modelBuilder.Entity<ForestUid>().HasOne(third => third.ThirdUid).WithMany();

            modelBuilder.Entity<TreeTypeSql>().HasOne(tree => tree.TreeSql).WithMany();
            modelBuilder.Entity<TreeTypeSql>().HasOne(tree => tree.PercentageSql).WithMany();

            //modelBuilder.Entity<ForestSql>().HasOne(forestUid => forestUid.ForestUidSql).WithOne();
            modelBuilder.Entity<ForestSql>().HasMany(plots => plots.PlotSqls).WithOne().HasForeignKey(sql => sql.ForestSqlId);

            #endregion
        }
        
        #region DbSets

        public virtual DbSet<TreeSql> TreeDbSet { get; set; }
        public virtual DbSet<PercentageSql> PercentageDbSet { get; set; }
        public virtual DbSet<ForestGroupSql> ForestGroupDbSet { get; set; }
        public virtual DbSet<ForestryEnterpriseSql> ForestryEnterpriseDbSet { get; set; }
        
        public virtual DbSet<ForestUidFirstSql> ForestUidFirstDbSet { get; set; }
        public virtual DbSet<ForestUidSecondSql> ForestUidSecondDbSet { get; set; }
        public virtual DbSet<ForestUidThirdSql> ForestUidThirdDbSet { get; set; }
        public virtual DbSet<PlotSql> PlotDbSet { get; set; }
        public virtual DbSet<ForestSql> ForestsDbSet { get; set; }
        
        public virtual DbSet<UserSql> UserDbSet { get; set; }
        
        #endregion

        public virtual DbSet<BidSql> BidsDbSet { get; set; }
        public virtual DbSet<AdminSql> AdminDbSet { get; set; }
          
    }
}