using System.Linq;
using AutoMapper;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.DataAccess.Entities;

namespace IIAuctionHouse.DataAccess.Converters
{
    public class PlotEntityToPlotConverter: ITypeConverter<PlotEntity, Plot>
    {
        public Plot Convert(PlotEntity pe, Plot p, ResolutionContext context)
        {
            return new Plot()
            {
                // Volume = pe.Volume,
                // PlotSize = pe.PlotSize,
                // PlotTenderness = pe.PlotTenderness,
                // AverageTreeHeight = pe.AverageTreeHeight,
                // PlotResolutionFirstValue = pe.PlotResolutionFirstValue,
                // PlotResolutionSecondValue = pe.PlotResolutionSecondValue,
                // Forest = new Forest()
                // {
                //     Id = pe.ForestEntity != null ? pe.ForestId : 0,
                //     ForestGroup = pe.ForestEntity != null ? pe.ForestEntity.ForestGroup : ""
                // },
                // TreeTypes = pe.TreeTypeEntities.Select(entity => new TreeType()
                // {
                //     Id = entity.Id,
                //     Name = entity.Name,
                //     Percentage = entity.Percentage
                // }).ToList(),
            };
        }
    }
    
    public class PlotToPlotEntityConverter : ITypeConverter<Plot, PlotEntity>
    {
        public PlotEntity Convert(Plot p, PlotEntity pe, ResolutionContext context)
        {
            return new PlotEntity()
            {
                Volume = p.Volume,
                PlotSize = p.PlotSize,
                PlotTenderness = p.PlotTenderness,
                AverageTreeHeight = p.AverageTreeHeight,
                
                // PlotTreeTypes = p.TreeTypes.Select(tt=> new TreeType()
                // {
                //     Id = tt.Id,
                //     Name = tt.Name,
                //     Percentage = tt.Percentage
               // }).ToList()
                // TreeTypeEntities = p.TreeTypes.Select(tt=> new TreeTypeEntity()
                // {
                //     Id = tt.Id,
                //     Name = tt.Name,
                //     Percentage = tt.Percentage
                // }).ToList()
            };
        }
    }
}