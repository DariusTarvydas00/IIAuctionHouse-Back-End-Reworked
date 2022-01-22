using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestGroupEntities.GroupEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestUidEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestUidEntities.EachUidEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.TreeTypeEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.TreeTypeEntities.TTEntities;
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


            modelBuilder.Entity<PlotSql>().HasMany<TreeTypeSql>(sql => sql.TreeTypeSql).WithOne()
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<ForestSql>().HasMany<PlotSql>(sql => sql.PlotSqls).WithOne()
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<ForestSql>().HasOne(uid => uid.ForestUidSql).WithMany()
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<ForestUidSql>().HasOne(first => first.ForestUidFirstSql).WithMany().OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<ForestUidSql>().HasOne(second => second.ForestUidSecondSql).WithMany().OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<ForestUidSql>().HasOne(third => third.ForestUidThirdSql).WithMany().OnDelete(DeleteBehavior.SetNull);

        }
        
        #region DbSets

        public virtual DbSet<GroupSql> GroupDbSet { get; set; }
        public virtual DbSet<SubGroupSql> SubGroupDbSet { get; set; }
        public virtual DbSet<TreeSql> TreeDbSet { get; set; }
        public virtual DbSet<PercentageSql> PercentageDbSet { get; set; }
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