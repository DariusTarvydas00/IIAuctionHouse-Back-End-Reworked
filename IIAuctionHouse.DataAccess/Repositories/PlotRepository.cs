using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Formats.Asn1;
using System.Linq;
using AutoMapper;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.DataAccess.Converters;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace IIAuctionHouse.DataAccess.Repositories
{
    public class PlotRepository: IPlotRepository
    {
        private readonly MainDbContext _ctx;
        private readonly IMapper _mapper;

        public PlotRepository(MainDbContext ctx)
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<Plot, PlotEntity>().ConvertUsing(new PlotToPlotEntityConverter());
                cfg.CreateMap<PlotEntity, Plot>().ConvertUsing(new PlotEntityToPlotConverter());
            });
            configuration.AssertConfigurationIsValid();
            _mapper = configuration.CreateMapper();
            _ctx = ctx;
        }
        
        public static void TryUpdateManyToMany<T, TKey>(MainDbContext db, IEnumerable<T> currentItems, IEnumerable<T> newItems, IEqualityComparer<T>? getKey) where T : class
        {
            db.Set<T>().RemoveRange(currentItems.Except(newItems, getKey));
            db.Set<T>().AddRange(newItems.Except(currentItems, getKey));
        }

        public static IEnumerable<T> Except<T, TKey>(IEnumerable<T> items, IEnumerable<T> other, Func<T, TKey> getKeyFunc)
        {
            return items
                .GroupJoin(other, getKeyFunc, getKeyFunc, (item, tempItems) => new { item, tempItems })
                .SelectMany(t => t.tempItems.DefaultIfEmpty(), (t, temp) => new { t, temp })
                .Where(t => ReferenceEquals(null, t.temp) || t.temp.Equals(default(T)))
                .Select(t => t.t.item);
        }
        
        public IEnumerable<Plot> FindAll()
        {
            return _ctx.PlotEntities.Select(entity => new Plot()
            {
                Id = entity.Id,
                PlotSize = entity.PlotSize,
                PlotResolution = entity.PlotResolution,
                PlotTenderness = entity.PlotTenderness,
                Volume = entity.Volume,
                AverageTreeHeight = entity.AverageTreeHeight,
            }).ToList();
        }

        public Plot GetById(int id)
        {
            return _ctx.PlotEntities.Select(ae => new Plot()
            {
                Id = ae.Id,
                PlotSize = ae.PlotSize,
                PlotResolution = ae.PlotResolution,
                PlotTenderness = ae.PlotTenderness,
                Volume = ae.Volume,
                AverageTreeHeight = ae.AverageTreeHeight,
                TreeTypes = ae.TreeTypesInE.Select(asd => new TreeType()
                {
                    Id = asd.TreeTypeEntity.Id,
                    Name = asd.TreeTypeEntity.Name,
                    Percentage = new Percentage()
                    {
                        Id = asd.TreeTypeEntity.PercentageEntity.Id,
                        PercentageValue = asd.TreeTypeEntity.PercentageEntity.PercentageEntityValue
                    }
                    
                }).ToList()
            }).FirstOrDefault(s=>s.Id == id); 
        }

        public Plot Create(Plot plot)
        {
                var cityEntry = _ctx.PlotEntities.Add(_mapper.Map<Plot, PlotEntity>(plot));
                _ctx.SaveChanges();
                var newCity = cityEntry.Entity;
                return _mapper.Map<PlotEntity, Plot>(newCity);
        }

        public Plot Update(Plot plot)
        {
            var entity = _ctx.PlotEntities.Update(new PlotEntity()
            {
                Id = plot.Id,
                PlotSize = plot.PlotSize,
                PlotResolution = plot.PlotResolution,
                PlotTenderness = plot.PlotTenderness,
                Volume = plot.Volume,
                AverageTreeHeight = plot.AverageTreeHeight
            }).Entity;
            _ctx.SaveChanges();
            return new Plot()
            {
                Id = entity.Id,
                PlotSize = entity.PlotSize,
                PlotResolution = entity.PlotResolution,
                PlotTenderness = entity.PlotTenderness,
                Volume = entity.Volume,
                AverageTreeHeight = entity.AverageTreeHeight,
            };
        }

        public Plot Delete(int id)
        {
            var entity = GetById(id);
            _ctx.PlotEntities.Remove(new PlotEntity()
            {
                Id = id
            });
            _ctx.SaveChanges();
            return new Plot()
            {
                Id = entity.Id,
                PlotSize = entity.PlotSize,
                PlotResolution = entity.PlotResolution,
                PlotTenderness = entity.PlotTenderness,
                Volume = entity.Volume,
                AverageTreeHeight = entity.AverageTreeHeight,
            };
        }
    }
}