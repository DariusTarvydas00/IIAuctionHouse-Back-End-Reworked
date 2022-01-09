using System;
using System.Collections.Generic;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.DataAccess
{
    public class MainDbContextSeeder: IMainDbContextSeeder
    {
        private readonly MainDbContext _ctx;
        private readonly IPercentageRepository _percentageRepository;
        private readonly ITreeRepository _treeRepository;
        private readonly IPlotRepository _plotRepository;

        public MainDbContextSeeder(MainDbContext ctx, 
            IPercentageRepository percentageRepository,
            ITreeRepository treeRepository,
            IPlotRepository plotRepository)
        {
            _ctx = ctx;
            _percentageRepository = percentageRepository;
            _treeRepository = treeRepository;
            _plotRepository = plotRepository;
        }

        public void SeedDevelopment()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();
            
            //-------- Percentage Entity -----------//
            for (int i = 1; i < 11; i++)
            {
                _percentageRepository.Create(new Percentage()
                {
                    Value = i * 10
                });
            }
            _ctx.SaveChanges();
            
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
            _ctx.SaveChanges();

            //-------- Plot Test Entity -------------//
             // for (int i=1; i<10; i++)
             // {
             //     Random random = new Random();
             //     int randomize = random.Next(1, 10);
             //     var newPlot = new PlotSql()
             //     {
             //         Volume = randomize*10,
             //         PlotResolution = "10"+randomize+"x"+"10"+randomize,
             //         PlotSize = randomize*10,
             //         PlotTenderness = randomize*10,
             //         AverageTreeHeight = randomize*10,
             //         TreeTypeSql = _ctx.TreeTypeDbSet.Add(new TreeTypeSql()
             //         {
             //             TreeSqlId = randomize,
             //             PercentageSqlId = randomize
             //         }).Entity
             //     };
             //     _ctx.PlotDbSet.Add(newPlot);
             // }
            
            _ctx.SaveChanges();
            //     treeTypeList.Add(treeType);
            // }
            //
            //
            // _ctx.SaveChanges();
            //
            // _plotRepository.Create(new Plot()
            // {
            //     Volume = 10,
            //     PlotResolution = "10",
            //     PlotSize = 12.1,
            //     PlotTenderness = 0.7,
            //     AverageTreeHeight = 23,
            //     TreeType = new TreeType()
            //     {
            //         Tree = new Tree()
            //         {
            //             Id = 1
            //         },
            //         Percentage = new Percentage()
            //         {
            //             Id = 1
            //         }
            //     }
            // });
            //
            // _plotRepository.Create(new Plot()
            // {
            //     Volume = 10,
            //     PlotResolution = "10",
            //     PlotSize = 12.1,
            //     PlotTenderness = 0.7,
            //     AverageTreeHeight = 23,
            //     TreeType = new TreeType()
            //     {
            //         Tree = new Tree()
            //         {
            //             Id = 1
            //         },
            //         Percentage = new Percentage()
            //         {
            //             Id = 1
            //         }
            //     }
            // });

            // _ctx.SaveChanges();
            // //
            // _plotRepository.Create(new Plot()
            // {
            //     Volume = 10,
            //     PlotResolution = "10",
            //     PlotSize = 12.1,
            //     PlotTenderness = 0.7,
            //     AverageTreeHeight = 23,
            //     TreeTypes = new TreeType()
            //     {
            //         Id = 1,
            //         Percentage = new Percentage()
            //         {
            //             Id = 5
            //         }
            //     }
            // });
            // _plotRepository.Create(new Plot()
            // {
            //     Volume = 10,
            //     PlotResolution = "10",
            //     PlotSize = 12.1,
            //     PlotTenderness = 0.7,
            //     AverageTreeHeight = 23,
            //     TreeTypes = new TreeType()
            //     {
            //         Id = 2,
            //         Percentage = new Percentage()
            //         {
            //             Value = 10
            //         }
            //     }
            // });
            //
            // _treeTypeRepository.Create(new TreeType()
            // {
            //     Name = "asd",
            //     Percentage = new Percentage()
            //     {
            //         Id = 1
            //     }
            // });
            
            _ctx.SaveChanges();
            
            // for (int i = 1; i < 11; i++)
            // {
            //     
            //     var treeType =_treeTypeRepository.Create(new TreeType()
            //     {
            //         Name = "TreeType" + i,
            //         Percentage = new Percentage()
            //         {
            //             Id = i
            //         }
            //     });
            //     treeTypeList.Add(treeType);
            // }
            //
            // _ctx.SaveChanges();
            //
            //
            // for (int i = 1; i < 11; i++)
            // {
            //     var treeType =_treeTypeRepository.Create(new TreeType()
            //     {
            //         Name = "TreeType" + i,
            //         Percentage = new Percentage()
            //         {
            //             Id = 1
            //         }
            //     });
            //     
            //     treeTypeList.Add(treeType);
            // }
            
            _ctx.SaveChanges();
            // _ctx.Plots.Add(new PlotEntity()
            // {
            //     Volume = 12,
            //
            // });
            //
            // var asd = new List<TreeTypeEntity>()
            // {
            //     new TreeTypeEntity()
            //     {
            //         Id = 1,
            //         Name = "treeType",
            //         Percentage = 10,
            //         PlotTreeTypes = new List<PlotTreeTypeEntity>()
            //         {
            //             new PlotTreeTypeEntity()
            //             {
            //                 PlotEntityId = 1
            //             }
            //         }
            //     }
            // };
            // _ctx.Plots.Add(new ()
            // {
            //     PlotSize = 1.1,
            //     PlotResolutionFirstValue = 22,
            //     PlotResolutionSecondValue = 137,
            //     PlotTenderness = 0.2,
            //     Volume = 600,
            //     AverageTreeHeight = 24,
            // });
            //
           
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
            
            // // -------- Tree Type Entity -----------//
            // var list = new List<TreeTypeEntity>();
            // for (int i = 1; i < 11; i++)
            // {
            //     Random randomNumber = new Random();
            //     int id = randomNumber.Next(1, 10);
            //     _ctx.TreeTypeEntities.Add(new TreeTypeEntity()
            //     {
            //         Name = "treeType" + i,
            //         PercentageEntityId = id
            //     });
            //     list.Add(new TreeTypeEntity()
            //     {
            //         Name = "treeType" + i,
            //         PercentageEntityId = id
            //     });
            // }
            //
            //
            // _ctx.PlotEntities.Add(new PlotEntity()
            // {
            //     Volume = 12,
            //     PlotResolution = "123x123",
            //     PlotSize = 12,
            //     PlotTenderness = 0.1,
            //     AverageTreeHeight = 23,
            //     TreeTypesInE = new List<PlotTreeTypeEntity>()
            //     {
            //         new PlotTreeTypeEntity()
            //         {
            //             TreeTypeEntityId = 1
            //         },
            //         new PlotTreeTypeEntity()
            //         {
            //             TreeTypeEntityId = 2
            //         }
            //     }
            // });
            // _ctx.PlotEntities.Add(new PlotEntity()
            // {
            //     Volume = 1,
            //     PlotResolution = "1x1",
            //     PlotSize = 1,
            //     PlotTenderness = 0.7,
            //     AverageTreeHeight = 50,
            //     TreeTypesInE = new List<PlotTreeTypeEntity>()
            //     {
            //         new PlotTreeTypeEntity()
            //         {
            //             TreeTypeEntityId = 2,
            //         },
            //         new PlotTreeTypeEntity()
            //         {
            //             TreeTypeEntityId = 1
            //         }
            //     }
            // });
            // _ctx.PlotTreeTypes.Add(new PlotTreeTypeEntity()
            // {
            //     PlotEntityId = 1,
            //     TreeTypeEntityId = 2
            // });
            _ctx.SaveChanges();
        }

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
            
        }
    }
}