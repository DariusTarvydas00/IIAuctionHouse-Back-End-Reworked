using System.Threading.Tasks.Dataflow;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.DataAccess.Entities;
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
            // //------ Many to Many Relationship -------//
            // modelBuilder.Entity<PlotTreeTypeEntity>().HasKey(ptt => new {ptt.TreeTypeEntityId, ptt.PlotEntityId});
            // modelBuilder.Entity<PlotTreeTypeEntity>().HasOne(ptt => ptt.TreeTypeEntity).
            //     WithMany(tt => tt.PlotTreeTypes).
            //     HasForeignKey(ptt => ptt.TreeTypeEntityId);
            // modelBuilder.Entity<PlotTreeTypeEntity>().HasOne(ptt => ptt.PlotEntity).
            //     WithMany(tt => tt.TreeTypes).
            //     HasForeignKey(ptt => ptt.PlotEntityId);
            //
            //
            
            //------ One to Many Relationship --------//
            // modelBuilder.Entity<PlotEntity>().HasOne<ForestEntity>(p => p.ForestEntity).
            //     WithMany(f => f.PlotEntities).
            //     HasForeignKey(p => p.ForestEntityId);
            //
            // modelBuilder.Entity<BidEntity>().HasOne<ForestEntity>(b => b.ForestEntity).
            //     WithMany(f => f.BidEntities).
            //     HasForeignKey(b => b.ForestEntityId);
            //
            // modelBuilder.Entity<BidEntity>().HasOne<UserEntity>(u => u.UserEntity).
            //     WithMany(f => f.BidEntities).
            //     HasForeignKey(b => b.UserEntityId);
            //
            // modelBuilder.Entity<ForestUIdEntity>().HasOne<UserEntity>(u => u.UserEntity).
            //     WithMany(f => f.ForestUIdsEntities).
            //     HasForeignKey(b => b.UserEntityId);
            //
            //------ One to One Relationship ---------//
            // modelBuilder.Entity<ForestUIdEntity>().HasOne<ForestEntity>(fu => fu.ForestEntity)
            //     .WithOne(f => f.ForestUidEntity).
            //     HasForeignKey<ForestEntity>(f => f.ForestUidId);
            //
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
            // modelBuilder.Entity<ForestEntity>().HasOne(fl => fl.ForestLocationEntity).
            //     WithMany().HasForeignKey(fl=> new {fl.ForestLocationEntityForeignKey}).OnDelete(DeleteBehavior.SetNull);
            // modelBuilder.Entity<ForestEntity>().HasOne(tg => tg.TreeGroupEntity).
            //     WithMany().HasForeignKey(tg=> new {tg.TreeGroupEntityForeignKey}).OnDelete(DeleteBehavior.SetNull);
            // modelBuilder.Entity<ForestEntity>().HasOne(tt => tt.TreeTypeEntity).
            //     WithMany().HasForeignKey(tt=> new {tt.TreeTypeEntityForeignKey}).OnDelete(DeleteBehavior.SetNull);
            //
            //
            //     modelBuilder.Entity<TreeTypeEntity>().HasOne(p => p.PercentageEntity).WithOne()
            //         .HasForeignKey<TreeTypeEntity>(p=>p.PercentageEntityForeignKey).OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<TreeTypeEntity>().HasOne(a => a.PlotEntity).WithMany(b => b.TreeTypeEntities).
            // //HasForeignKey(a=>a.PlotId);
            // modelBuilder.Entity<PlotEntity>().HasOne(a => a.ForestEntity).WithMany(c => c.PlotEntities)
            //     .HasForeignKey(a => new {a.ForestEntity}).OnDelete(DeleteBehavior.NoAction);
            
            
            
            
            
            
            
            // modelBuilder.Entity<TreeTypeEntity>().HasOne<PercentageEntity>(tt => tt.PercentageEntity)
            //     .WithMany(entity => entity.TreeTypeEntities)
            //     .HasForeignKey(entity => entity.PercentageEntityId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PercentageEntity>().HasMany(entity => entity.TreeTypeEntities)
                .WithOne(entity => entity.PercentageEntity)
                .HasForeignKey(entity => entity.PercentageEntityId)
                .OnDelete(DeleteBehavior.SetNull);
        }

        public virtual DbSet<ForestEntity> Forests { get; set; }

        public virtual DbSet<PlotTreeTypeEntity> PlotTreeTypes { get; set; }
        public virtual DbSet<PlotEntity> Plots { get; set; }
        public virtual DbSet<TreeTypeEntity> TreeTypes { get; set; }
        public virtual DbSet<PercentageEntity> PercentageEntities { get; set; }
        public virtual DbSet<UserEntity> UserEntities { get; set; }
        public virtual DbSet<ForestUIdEntity> ForestUIdEntities { get; set; }
        public virtual DbSet<BidEntity> BidEntities { get; set; }
        
    }
}