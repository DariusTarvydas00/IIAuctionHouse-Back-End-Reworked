using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;
using IIAuctionHouse.DataAccess.Converters.ForestDetailConverters.PlotConverters.TreeTypeConverters;
using IIAuctionHouse.DataAccess.Exceptions;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IPlotDetailRepositories.ITreeTypeRepositories;
using Microsoft.EntityFrameworkCore;

namespace IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories.PlotRepositories.TreeTypeRepositories
{
    public class PercentageRepository : IPercentageRepository
    {
        private readonly MainDbContext _ctx;
        private readonly PercentageConverter _percentageConverter;

        public PercentageRepository(MainDbContext ctx, PercentageConverter percentageConverter)
        {
            _ctx = ctx ?? throw new NullReferenceException(DataAccessExceptions.NullContext);
            _percentageConverter = percentageConverter ?? throw new NullReferenceException(DataAccessExceptions.NullConverter);
        }

        public IEnumerable<Percentage> FindAll()
        {
            return _ctx.PercentageDbSet.OrderBy(sql => sql.Value).Select(percentageSql => new Percentage()
            {
                Id = percentageSql.Id,
                Value = percentageSql.Value
            }).ToList();
        }
        
        public Percentage GetById(int id)
        {
            return _ctx.PercentageDbSet.Select(tree => new Percentage()
            {
                Id = tree.Id,
                Value = tree.Value,
            }).FirstOrDefault(tree => tree.Id == id);
        }

        public Percentage Create(Percentage percentage)
        {
            var exists = _ctx.PercentageDbSet.Any(sql => sql.Value == percentage.Value);
            if (exists) throw new InvalidOperationException(DataAccessExceptions.EntityExists);
            var newPercentage = _ctx.PercentageDbSet.Add(_percentageConverter.Convert(percentage)).Entity;
            _ctx.SaveChanges();
            return _percentageConverter.Convert(newPercentage);
        }

        public Percentage Update(Percentage percentage)
        {
            var exists = _ctx.PercentageDbSet.Any(sql => sql.Value == percentage.Value);
            if (exists) throw new InvalidOperationException(DataAccessExceptions.EntityExists);
            var check = _ctx.PercentageDbSet.AsNoTracking().FirstOrDefault(sql => sql.Id == percentage.Id);
            if (check == null) throw new InvalidOperationException(DataAccessExceptions.NotFound);
            var percentageUpdate = _ctx.PercentageDbSet.Update(_percentageConverter.Convert(percentage)).Entity;
            _ctx.SaveChanges();
            return _percentageConverter.Convert(percentageUpdate);
        }

        public Percentage Delete(int id)
        {
            var percentageSql = _ctx.PercentageDbSet.FirstOrDefault(percentageSql => percentageSql.Id == id);
            if (percentageSql == null) throw new InvalidOperationException(DataAccessExceptions.NotFound);
            _ctx.PercentageDbSet.Remove(percentageSql);
            _ctx.SaveChanges();
            return _percentageConverter.Convert(percentageSql);
        }
    }
}