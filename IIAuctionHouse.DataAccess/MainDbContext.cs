using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.ForestUid;
using IIAuctionHouse.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IIAuctionHouse.DataAccess
{
    public class MainDbContext: DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
              modelBuilder.Entity<Percentage>().ToTable(nameof(Percentage), t => t.ExcludeFromMigrations());
              modelBuilder.Entity<Tree>().ToTable(nameof(Tree), t => t.ExcludeFromMigrations());
              modelBuilder.Entity<TreeType>().ToTable(nameof(TreeType), t => t.ExcludeFromMigrations());
              modelBuilder.Entity<Plot>().ToTable(nameof(Plot), t => t.ExcludeFromMigrations());
              modelBuilder.Entity<Forest>().ToTable(nameof(Forest), t => t.ExcludeFromMigrations());
              modelBuilder.Entity<ForestLocation>().ToTable(nameof(ForestLocation), t => t.ExcludeFromMigrations());
              modelBuilder.Entity<ForestUidFirst>().ToTable(nameof(ForestUidFirst), t => t.ExcludeFromMigrations());
              modelBuilder.Entity<ForestUidSecond>().ToTable(nameof(ForestUidSecond), t => t.ExcludeFromMigrations());
              modelBuilder.Entity<ForestUidThird>().ToTable(nameof(ForestUidThird), t => t.ExcludeFromMigrations());
              modelBuilder.Entity<ForestUid>().ToTable(nameof(ForestUid), t => t.ExcludeFromMigrations());

              modelBuilder.Entity<ForestUid>().HasOne(first => first.FirstUid).WithMany();
              modelBuilder.Entity<ForestUid>().HasOne(second => second.SecondUid).WithMany();
              modelBuilder.Entity<ForestUid>().HasOne(third => third.ThirdUid).WithMany();
              
              modelBuilder.Entity<TreeTypeSql>().HasOne(tree => tree.TreeSql).WithMany();
              modelBuilder.Entity<TreeTypeSql>().HasOne(tree => tree.PercentageSql).WithMany();
        }

        #region Forest Uid Db Sets

        public virtual DbSet<ForestUidSql> ForestUidDbSet { get; set; }
        public virtual DbSet<ForestUidFirstSql> ForestUidFirstDbSet { get; set; }
        public virtual DbSet<ForestUidSecondSql> ForestUidSecondDbSet { get; set; }
        public virtual DbSet<ForestUidThirdSql> ForestUidThirdDbSet { get; set; }
        
        #endregion

        #region TreeType Tree and Percentage DbSets

        
        public virtual DbSet<TreeSql> TreeDbSet { get; set; }
        public virtual DbSet<PercentageSql> PercentageDbSet { get; set; }
        public virtual DbSet<TreeTypeSql> TreeTypeDbSet { get; set; }

        #endregion
        
        
        public virtual DbSet<PlotSql> PlotDbSet { get; set; }
        public virtual DbSet<ForestSql> ForestsDbSet { get; set; }
        public virtual DbSet<ForestLocationSql> ForestLocationDbSet { get; set; }
        
        public virtual DbSet<ForestGroupSql> ForestGroupDbSet { get; set; }
        
        

        public virtual DbSet<UserSql> UserDbSet { get; set; }
        
        public virtual DbSet<ForestryEnterpriseSql> ForestryEnterpriseDbSet { get; set; }

        public virtual DbSet<BidSql> BidsDbSet { get; set; }
        public virtual DbSet<AdminSql> AdminDbSet { get; set; }
        
        
        
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

               // modelBuilder.Entity<Forest>().ToTable(nameof(Forest), t => t.ExcludeFromMigrations());
               // modelBuilder.Entity<ForestLocation>().ToTable(nameof(ForestLocation), t => t.ExcludeFromMigrations());
               // modelBuilder.Entity<ForestryEnterpriseSql>().ToTable(nameof(ForestryEnterpriseSql), t => t.ExcludeFromMigrations());
               // modelBuilder.Entity<ForestUid>().ToTable(nameof(ForestUid), t => t.ExcludeFromMigrations());
               // modelBuilder.Entity<Bid>().ToTable(nameof(Bid), t => t.ExcludeFromMigrations());
               // modelBuilder.Entity<User>().ToTable(nameof(User), t => t.ExcludeFromMigrations());
               // modelBuilder.Entity<Admin>().ToTable(nameof(Admin), t => t.ExcludeFromMigrations());

               // modelBuilder.Entity<TreeTypeSql>().HasOne<PercentageSql>(sql => sql.PercentageSql).WithMany()
               //     .HasForeignKey(sql => new {sql.PercentageSqlId});
               // modelBuilder.Entity<TreeTypeSql>().HasMany<PercentageSql>(ptt => ptt.PercentageSql).
               //     WithMany(tt => tt.PlotTreeTypes).
               //     HasForeignKey(ptt => ptt.TreeTypeEntityId);
               // modelBuilder.Entity<PlotTreeTypeEntity>().HasOne(ptt => ptt.PlotEntity).
               //     WithMany(tt => tt.TreeTypes).
               //     HasForeignKey(ptt => ptt.PlotEntityId);
               //
               //

               //------ One to Many Relationship --------//

               // modelBuilder.Entity<ForestEntity>().HasMany(entity => entity.PlotEntities)
               //     .WithOne(entity => entity.ForestEntity)
               //     .HasForeignKey(entity => entity.ForestEntityId)
               //     .OnDelete(DeleteBehavior.SetNull);
               // //
               // modelBuilder.Entity<UserEntity>().HasMany(entity => entity.BidEntities)
               //     .WithOne(entity => entity.UserEntity)
               //     .HasForeignKey(entity => entity.UserEntityId)
               //     .OnDelete(DeleteBehavior.SetNull);
               //
               // modelBuilder.Entity<ForestEntity>().HasOne<ForestryEnterpriseEntity>(entity => entity.ForestryEnterpriseEntity)
               //     .WithMany(entity => entity.ForestEntities).HasForeignKey(entity => entity.ForestryEnterpriseId)
               //     .OnDelete(DeleteBehavior.SetNull);
               //
               // // modelBuilder.Entity<PlotSql>().HasOne<ForestEntity>(entity => entity.ForestEntity)
               // //     .WithMany(entity => entity.PlotEntities).HasForeignKey(entity => entity.ForestEntityId)
               // //     .OnDelete(DeleteBehavior.SetNull);
               // //
               // modelBuilder.Entity<ForestUidEntity>().HasOne<UserEntity>(entity => entity.UserEntity)
               //     .WithMany(entity => entity.ForestUidEntities).HasForeignKey(entity => entity.UserEntityId)
               //     .OnDelete(DeleteBehavior.SetNull);
               //
               //
               // //------ One to one  --------//
               //
               //  modelBuilder.Entity<ForestUidEntity>().HasOne<ForestEntity>(f => f.ForestEntity)
               //      .WithOne(fl => fl.ForestUidEntity)
               //      .HasForeignKey<ForestEntity>(f => f.ForestUidEntityId).OnDelete(DeleteBehavior.SetNull);
               // modelBuilder.Entity<ForestLocationEntity>().HasOne(f => f.ForestEntity)
               //     .WithOne(fl => fl.ForestLocationEntity)
               //     .HasForeignKey<ForestEntity>(f => f.ForestLocationEntityId).OnDelete(DeleteBehavior.SetNull);
               //
               // /*
               //  * Many To Many Relation Ships
               //  */
               //
               // modelBuilder.Entity<TreeTypePercentageSql>().HasKey(ptt => new {ptt.TreeTypeEntityId, ptt.PercentageSqlId});
               // modelBuilder.Entity<TreeTypePercentageSql>()
               //     .HasOne<PercentageSql>(e => e.PercentageSql)
               //     .WithMany(entity => entity.TreeTypePercentageSqls).HasForeignKey(sc=>sc.PercentageSqlId);
               // modelBuilder.Entity<TreeTypePercentageSql>()
               //     .HasOne<TreeTypeSql>(e => e.TreeTypeSql)
               //     .WithMany(entity => entity.TreeTypePercentageSqls).HasForeignKey(sc=>sc.TreeTypeEntityId);
               //

               /*
                * One To Many Relation Ships
                */

               /*
               * One To One Relation Ships
               */

               // modelBuilder.Entity<PercentageSql>().HasMany()<TreeTypeSql>(entity => entity.TreeTypeSql)
               //     .Has(entity => entity.PercentageSql)
               //     .HasForeignKey<TreeTypeSql>(entity => entity.PercentageSqlId)
               // //     .OnDelete(DeleteBehavior.SetNull);
               // modelBuilder.Entity<PlotSql>().HasMany<TreeTypeSql>(entity => entity.TreeTypeSql)
               //     .WithOne(entity => entity.PercentageSql)
               //     .HasForeignKey<TreeTypeSql>(entity => entity.PercentageSqlId)
               //     .OnDelete(DeleteBehavior.SetNull);



               // modelBuilder.Entity<PlotSql>().HasOne<TreeTypeSql>(sql => sql.TreeTypeSql)
               //     .WithOne(sql => sql.PlotSql).HasForeignKey<TreeTypeSql>(sql => sql.PlotSqlId);
               //
               // modelBuilder.Entity<TreeTypeSql>().HasOne<PercentageSql>(sql => sql.PercentageSql)
               //     .WithOne(sql => sql.TreeTypeSql).HasForeignKey<PercentageSql>(sql => sql.TreeTypeSqlId);
            
            
            // modelBuilder.Entity<PlotEntity>().HasMany<TreeTypeEntity>(entity => entity.TreeTypeEntities)
            //     .WithMany(entity => entity.PlotEntities).
            // modelBuilder.Entity<PlotTreeTypeEntity>().HasKey(ptt => new {ptt.PlotEntityId, ptt.TreeTypeEntityId});
            // modelBuilder.Entity<PlotTreeTypeEntity>().HasOne(p => p.PlotEntity)
            //     .WithMany(p => p.TreeTypeEntities).HasForeignKey(ptt => ptt.PlotEntityId);
            // modelBuilder.Entity<PlotTreeTypeEntity>().HasOne(p => p.TreeTypeEntity)
            //     .WithMany(p => p.PlotEntities).HasForeignKey(ptt => ptt.TreeTypeEntityId);
            //
                // .UsingEntity<>(
                //     bg => bg
                //         .HasOne(bg => bg.PlotEntity)
                //         .WithMany()
                //         .HasForeignKey("PlotEntityId"),
                //     bg => bg
                //         .HasOne(bg => bg.TreeTypeEntity)
                //         .WithMany()
                //         .HasForeignKey("TreeTypeEntityId"))
                // .ToTable("BookGenres")
                // .HasKey(bg => new { bg.PlotEntityId, bg.TreeTypeEntityId });
            
            
            
            // modelBuilder.Entity<TreeTypeEntity>().HasOne<PercentageEntity>(tt => tt.PercentageEntity)
            //     .WithMany(entity => entity.TreeTypeEntities)
            //     .HasForeignKey(entity => entity.PercentageEntityId).OnDelete(DeleteBehavior.Cascade);
          
    }
}