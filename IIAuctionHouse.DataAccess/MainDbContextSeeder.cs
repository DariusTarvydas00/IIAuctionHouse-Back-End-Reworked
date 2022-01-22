using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestGroupEntities.GroupEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestUidEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestUidEntities.EachUidEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.TreeTypeEntities.TTEntities;

namespace IIAuctionHouse.DataAccess
{
    public class MainDbContextSeeder: IMainDbContextSeeder
    {
        private readonly MainDbContext _ctx;

        public MainDbContextSeeder(MainDbContext ctx)
        {
            _ctx = ctx;
        }


        #region Development
        
        public void SeedDevelopment()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();

            #region Percentage Entities

            for (int i = 1; i < 11; i++)
            {
                _ctx.PercentageDbSet.Add(new PercentageSql()
                {
                    Value = i * 10
                });
            }
            _ctx.SaveChanges();

            #endregion

            #region Tree Entities

            _ctx.TreeDbSet.Add(new TreeSql()
            {
                Name = "Pine"
            });
            _ctx.TreeDbSet.Add(new TreeSql()
            {
                Name = "Fir"
            });
            _ctx.TreeDbSet.Add(new TreeSql()
            {
                Name = "Birch"
            });
            _ctx.TreeDbSet.Add(new TreeSql()
            {
                Name = "Oak"
            });
            _ctx.TreeDbSet.Add(new TreeSql()
            {
                Name = "Aspen"
            });
            _ctx.SaveChanges();
            

            #endregion

            #region Forestry Enterprise Entites

            _ctx.ForestryEnterpriseDbSet.Add(new ForestryEnterpriseSql()
            {
                Name = "Vilnius"
            });
            _ctx.ForestryEnterpriseDbSet.Add(new ForestryEnterpriseSql()
            {
                Name = "Kaunas"
            });
            _ctx.ForestryEnterpriseDbSet.Add(new ForestryEnterpriseSql()
            {
                Name = "Taurage"
            });
            _ctx.ForestryEnterpriseDbSet.Add(new ForestryEnterpriseSql()
            {
                Name = "Klaipeda"
            });
            _ctx.ForestryEnterpriseDbSet.Add(new ForestryEnterpriseSql()
            {
                Name = "Silale"
            });
            _ctx.ForestryEnterpriseDbSet.Add(new ForestryEnterpriseSql()
            {
                Name = "Siauliai"
            });
            _ctx.ForestryEnterpriseDbSet.Add(new ForestryEnterpriseSql()
            {
                Name = "Silute"
            });
            _ctx.SaveChanges();
            

            #endregion

            #region Forest Group Entities

            _ctx.GroupDbSet.Add(new GroupSql()
            {
                ForestGroupName = "I"
            });
            _ctx.GroupDbSet.Add(new GroupSql()
            {
                ForestGroupName = "II"
            });
            _ctx.GroupDbSet.Add(new GroupSql()
            {
                ForestGroupName = "II"
            });
            _ctx.GroupDbSet.Add(new GroupSql()
            {
                ForestGroupName = "IV"
            });
            _ctx.SaveChanges();
            

            #endregion
            
            #region Forest Sub Group Entities

            _ctx.SubGroupDbSet.Add(new SubGroupSql()
            {
                ForestSubGroupName = "A"
            });
            _ctx.SubGroupDbSet.Add(new SubGroupSql()
            {
                ForestSubGroupName = "B"
            });
            _ctx.SaveChanges();
            

            #endregion

            #region Forest Uid Entities

            for (int i = 1; i < 11; i++)
            {
                _ctx.ForestUidFirstDbSet.Add(new ForestUidFirstSql()
                {
                    Value = i * 10
                });
                _ctx.ForestUidSecondDbSet.Add(new ForestUidSecondSql()
                {
                    Value = i * 10
                });
                _ctx.ForestUidThirdDbSet.Add(new ForestUidThirdSql()
                {
                    Value = i * 10
                });
                
            }
            _ctx.SaveChanges();

            #endregion

        }

        #endregion

        #region Production
        
        public void SeedProduction()
        {
            #region Percentage Entities

            for (int i = 1; i < 11; i++)
            {
                _ctx.PercentageDbSet.Add(new PercentageSql()
                {
                    Value = i * 10
                });
            }
            _ctx.SaveChanges();

            #endregion

            #region Tree Entities

            _ctx.TreeDbSet.Add(new TreeSql()
            {
                Name = "Pine"
            });
            _ctx.TreeDbSet.Add(new TreeSql()
            {
                Name = "Fir"
            });
            _ctx.TreeDbSet.Add(new TreeSql()
            {
                Name = "Birch"
            });
            _ctx.TreeDbSet.Add(new TreeSql()
            {
                Name = "Oak"
            });
            _ctx.TreeDbSet.Add(new TreeSql()
            {
                Name = "Aspen"
            });
            _ctx.SaveChanges();
            

            #endregion

            #region Forestry Enterprise Entites

            _ctx.ForestryEnterpriseDbSet.Add(new ForestryEnterpriseSql()
            {
                Name = "Vilnius"
            });
            _ctx.ForestryEnterpriseDbSet.Add(new ForestryEnterpriseSql()
            {
                Name = "Kaunas"
            });
            _ctx.ForestryEnterpriseDbSet.Add(new ForestryEnterpriseSql()
            {
                Name = "Taurage"
            });
            _ctx.ForestryEnterpriseDbSet.Add(new ForestryEnterpriseSql()
            {
                Name = "Klaipeda"
            });
            _ctx.ForestryEnterpriseDbSet.Add(new ForestryEnterpriseSql()
            {
                Name = "Silale"
            });
            _ctx.ForestryEnterpriseDbSet.Add(new ForestryEnterpriseSql()
            {
                Name = "Siauliai"
            });
            _ctx.ForestryEnterpriseDbSet.Add(new ForestryEnterpriseSql()
            {
                Name = "Silute"
            });
            _ctx.SaveChanges();
            

            #endregion

            #region Forest Group Entities

            _ctx.GroupDbSet.Add(new GroupSql()
            {
                ForestGroupName = "I"
            });
            _ctx.GroupDbSet.Add(new GroupSql()
            {
                ForestGroupName = "II"
            });
            _ctx.GroupDbSet.Add(new GroupSql()
            {
                ForestGroupName = "II"
            });
            _ctx.GroupDbSet.Add(new GroupSql()
            {
                ForestGroupName = "IV"
            });
            _ctx.SaveChanges();
            

            #endregion
            
            #region Forest Sub Group Entities

            _ctx.SubGroupDbSet.Add(new SubGroupSql()
            {
                ForestSubGroupName = "A"
            });
            _ctx.SubGroupDbSet.Add(new SubGroupSql()
            {
                ForestSubGroupName = "B"
            });
            _ctx.SaveChanges();
            

            #endregion
            
        }
        
        #endregion
    }
}