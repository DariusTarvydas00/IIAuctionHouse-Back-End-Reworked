using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestUidEntities;
using IIAuctionHouse.Domain.IRepositories;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestUidRepositories;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestUidRepositories.IEachUidRepositories;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IPlotDetailRepositories;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IPlotDetailRepositories.ITreeTypeRepositories;

namespace IIAuctionHouse.DataAccess
{
    public class MainDbContextSeeder: IMainDbContextSeeder
    {
        private readonly MainDbContext _ctx;
        private readonly IPercentageRepository _percentageRepository;
        private readonly ITreeRepository _treeRepository;
        private readonly IPlotRepository _plotRepository;
        private readonly IForestEnterpriseRepository _forestEnterpriseRepository;
        private readonly IForestGroupRepository _forestGroupRepository;
        private readonly IForestFirstUidRepository _forestFirstUidRepository;
        private readonly IForestSecondUidRepository _forestSecondUidRepository;
        private readonly IForestThirdUidRepository _forestThirdUidRepository;

        public MainDbContextSeeder(MainDbContext ctx, 
            IPercentageRepository percentageRepository,
            ITreeRepository treeRepository,
            IPlotRepository plotRepository,
            IForestEnterpriseRepository forestEnterpriseRepository,
            IForestGroupRepository forestGroupRepository,
            IForestFirstUidRepository forestFirstUidRepository,
            IForestSecondUidRepository forestSecondUidRepository,
            IForestThirdUidRepository forestThirdUidRepository)
        {
            _ctx = ctx;
            _percentageRepository = percentageRepository;
            _treeRepository = treeRepository;
            _plotRepository = plotRepository;
            _forestEnterpriseRepository = forestEnterpriseRepository;
            _forestGroupRepository = forestGroupRepository;
            _forestFirstUidRepository = forestFirstUidRepository;
            _forestSecondUidRepository = forestSecondUidRepository;
            _forestThirdUidRepository = forestThirdUidRepository;

        }

        public void SeedDevelopment()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();

            #region Percentage Entities

            for (int i = 1; i < 11; i++)
            {
                _percentageRepository.Create(new Percentage()
                {
                    Value = i * 10
                });
            }
            _ctx.SaveChanges();

            #endregion

            #region Tree Entities

            _treeRepository.Create(new Tree()
            {
                Name = "Pine"
            });
            _treeRepository.Create(new Tree()
            {
                Name = "Fir"
            });
            _treeRepository.Create(new Tree()
            {
                Name = "Birch"
            });
            _treeRepository.Create(new Tree()
            {
                Name = "Oak"
            });
            _treeRepository.Create(new Tree()
            {
                Name = "Aspen"
            });
            _ctx.SaveChanges();
            

            #endregion

            #region Forestry Enterprise Entites

            _forestEnterpriseRepository.Create(new ForestryEnterprise()
            {
                Name = "Vilnius"
            });
            _forestEnterpriseRepository.Create(new ForestryEnterprise()
            {
                Name = "Kaunas"
            });
            _forestEnterpriseRepository.Create(new ForestryEnterprise()
            {
                Name = "Taurage"
            });
            _forestEnterpriseRepository.Create(new ForestryEnterprise()
            {
                Name = "Klaipeda"
            });
            _forestEnterpriseRepository.Create(new ForestryEnterprise()
            {
                Name = "Silale"
            });
            _forestEnterpriseRepository.Create(new ForestryEnterprise()
            {
                Name = "Siauliai"
            });
            _forestEnterpriseRepository.Create(new ForestryEnterprise()
            {
                Name = "Silute"
            });
            _ctx.SaveChanges();
            

            #endregion

            #region Forest Group Entities

            _forestGroupRepository.Create(new ForestGroup()
            {
                Name = "A"
            });
            _forestGroupRepository.Create(new ForestGroup()
            {
                Name = "B"
            });
            _forestGroupRepository.Create(new ForestGroup()
            {
                Name = "C"
            });
            _forestGroupRepository.Create(new ForestGroup()
            {
                Name = "D"
            });
            _ctx.SaveChanges();
            

            #endregion

            #region Forest Uid Entities

            #region Forest First Uid Entites

            for (int i = 1; i < 10; i++)
            {
                _forestFirstUidRepository.Create(new ForestUidFirst()
                {
                    Value = i*10
                });
            }
            _ctx.SaveChanges();

            #endregion

            #region Forest Second Uid Entities

            for (int i = 1; i < 10; i++)
            {
                _forestSecondUidRepository.Create(new ForestUidSecond()
                {
                    Value = i*40
                });
            }
            _ctx.SaveChanges();

            #endregion

            #region Forest Third Uid Entities

            for (int i = 1; i < 10; i++)
            {
                _forestThirdUidRepository.Create(new ForestUidThird()
                {
                    Value = i*80
                });
            }
            _ctx.SaveChanges();

            #endregion

            #endregion
        }

        #region Production
        
        public void SeedProduction()
        {
            //-------- Percentage Entity -----------//
            for (int i = 1; i < 11; i++)
            {
                _percentageRepository.Create(new Percentage()
                {
                    Value = i * 10
                });
            }
            
            //-------- Tree Entity -----------------//
            _treeRepository.Create(new Tree()
            {
                Name = "Pine"
            });
            _treeRepository.Create(new Tree()
            {
                Name = "Fir"
            });
            _treeRepository.Create(new Tree()
            {
                Name = "Birch"
            });
            _treeRepository.Create(new Tree()
            {
                Name = "Oak"
            });
            _treeRepository.Create(new Tree()
            {
                Name = "Aspen"
            });
            
            //-------- Forest Uid Entities -----------------//
            
            var list = new List<ForestUidFirstSql>();
            var list2 = new List<ForestUidSecondSql>();
            var list3 = new List<ForestUidThirdSql>();
            for (int i = 1; i < 10000; i++)
            {
                list.Add(new ForestUidFirstSql()
                {
                    Id = i,
                    Value = i
                });
                list2.Add(new ForestUidSecondSql()
                {
                    Id = i,
                    Value = i
                });
                list3.Add(new ForestUidThirdSql()
                {
                    Id = i,
                    Value = i
                });
            }
            _ctx.ForestUidFirstDbSet.AddRange(list);
            _ctx.ForestUidSecondDbSet.AddRange(list2); 
            _ctx.ForestUidThirdDbSet.AddRange(list3);
            
        }
        
        #endregion
    }
}