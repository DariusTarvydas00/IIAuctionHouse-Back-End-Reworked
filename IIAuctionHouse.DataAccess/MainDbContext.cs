using IIAuctionHouse.Core.Models.Forest;
using IIAuctionHouse.DataAccess.Entities.ForestEntities;
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
            //------ One to one  --------//
            // modelBuilder.Entity<ForestLocationEntity>().HasOne(f => f.ForestEntity)
            //     .WithOne(fl => fl.ForestLocationEntity)
            //     .HasForeignKey<ForestEntity>(f => f.ForestLocationEntityForeignKey);
            // modelBuilder.Entity<TreeGroupEntity>().HasOne(f => f.ForestEntity)
            //     .WithOne(fl => fl.TreeGroupEntity)
            //     .HasForeignKey<ForestEntity>(f => f.TreeGroupEntityForeignKey);
            // modelBuilder.Entity<TreeTypeEntity>().HasOne(f => f.ForestEntity)
            //     .WithOne(fl => fl.TreeTypeEntity)
            //     .HasForeignKey<ForestEntity>(f => f.TreeTypeEntityForeignKey);
            //------ One to many --------//
            modelBuilder.Entity<ForestEntity>().HasOne(fl => fl.ForestLocationEntity).
                WithMany().HasForeignKey(fl=> new {fl.ForestLocationEntityForeignKey}).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<ForestEntity>().HasOne(tg => tg.TreeGroupEntity).
                WithMany().HasForeignKey(tg=> new {tg.TreeGroupEntityForeignKey}).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<ForestEntity>().HasOne(tt => tt.TreeTypeEntity).
                WithMany().HasForeignKey(tt=> new {tt.TreeTypeEntityForeignKey}).OnDelete(DeleteBehavior.SetNull);
        }

        public virtual DbSet<ForestEntity> Forests { get; set; }
        public virtual DbSet<ForestLocationEntity> ForestLocations { get; set; }
        public virtual DbSet<TreeTypeEntity> TreeTypes { get; set; }
        public virtual DbSet<TreeGroupEntity> TreeGroups { get; set; }
    }
}