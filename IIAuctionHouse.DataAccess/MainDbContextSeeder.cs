using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.DataAccess.Converters;
using IIAuctionHouse.DataAccess.Entities;
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
            
            // _ctx.TreeTypes.Add(new TreeTypeEntity()
            // {
            //     Name = "TreeType1",
            //     Percentage = 10
            // });
            // _ctx.TreeTypes.Add(new TreeTypeEntity()
            // {
            //     Name = "TreeType2",
            //     Percentage = 20
            // });
            // _ctx.TreeTypes.Add(new TreeTypeEntity()
            // {
            //     Name = "TreeType3",
            //     Percentage = 30
            // });
            // var treeTypeList = new List<TreeType>();
            // for (int i = 1; i <10; i++)
            // {
            //     var newTreeType = new TreeType()
            //     {
            //         Id = i,
            //         Name = "treeType" + i,
            //         Percentage = i * 10,
            //     };
            //     treeTypeList.Add(newTreeType);
            //     _ctx.TreeTypes.Add(new TreeTypeEntity()
            //     {
            //         Id = i,
            //         Name = "treeType" + i,
            //         Percentage = i * 10,
            //         
            //     });
            // }
            //
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
            
            
            // -------- Percentage Entity -----------//
            // for (int i = 1; i < 11; i++)
            // {
            //     _ctx.PercentageEntities.Add(new PercentageEntity()
            //     {
            //         PercentageEntityValue = i * 10,
            //     });
            // }
            //
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
            // -------- Percentage Entity -----------//
            for (int i = 1; i < 11; i++)
            {
                _ctx.PercentageEntities.Add(new PercentageEntity()
                {
                    PercentageEntityValue = i * 10,
                });
            }
            
            // -------- Tree Type Entity -----------//
            _ctx.TreeTypeEntities.Add(new TreeTypeEntity()
            {
                Name = "Pine",
                PercentageEntity = new PercentageEntity() { }
            });
            _ctx.TreeTypeEntities.Add(new TreeTypeEntity()
            {
                Name = "Fir",
                PercentageEntity = new PercentageEntity() { }
            });
            _ctx.TreeTypeEntities.Add(new TreeTypeEntity()
            {
                Name = "Birch",
                PercentageEntity = new PercentageEntity() { }
            });
            _ctx.TreeTypeEntities.Add(new TreeTypeEntity()
            {
                Name = "Oak",
                PercentageEntity = new PercentageEntity() { }
            });
            _ctx.TreeTypeEntities.Add(new TreeTypeEntity()
            {
                Name = "Aspen",
                PercentageEntity = new PercentageEntity() { }
            });
        }
    }
}