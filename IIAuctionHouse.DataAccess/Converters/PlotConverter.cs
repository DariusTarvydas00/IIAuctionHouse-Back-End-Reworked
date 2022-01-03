using System.Collections.Generic;
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
                Id = pe.Id,
                Volume = pe.Volume,
                PlotSize = pe.PlotSize,
                PlotTenderness = pe.PlotTenderness,
                AverageTreeHeight = pe.AverageTreeHeight,
                PlotResolution = pe.PlotResolution,
                TreeTypes = pe.TreeTypesInE.Select(asd=>new TreeType()
                {
                    Id = asd.TreeTypeEntityId,
                }).ToList()
            };
        }
    }
    
    public class PlotToPlotEntityConverter : ITypeConverter<Plot, PlotEntity>
    {
        public PlotEntity Convert(Plot p, PlotEntity pe, ResolutionContext context)
        {
            return new PlotEntity()
            {
                Id = p.Id,
                Volume = p.Volume,
                PlotSize = p.PlotSize,
                PlotTenderness = p.PlotTenderness,
                AverageTreeHeight = p.AverageTreeHeight,
                PlotResolution = p.PlotResolution,
                TreeTypesInE = p.TreeTypes.Select(asd => new PlotTreeTypeEntity()
                {
                    TreeTypeEntityId = asd.Id
                }).ToList()
                    //                   == null ? new List<PlotTreeTypeEntity>() :
                    // p.TreeTypes.Select(t=>new PlotTreeTypeEntity
                    // {
                    //     TreeTypeEntityId = t.Id,
                    // }).ToList()
            };
        }
    }
}