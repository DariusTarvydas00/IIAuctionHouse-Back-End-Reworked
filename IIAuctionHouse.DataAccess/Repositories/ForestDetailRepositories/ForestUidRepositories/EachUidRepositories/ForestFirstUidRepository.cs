using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;
using IIAuctionHouse.DataAccess.Converters.ForestDetailConverters.ForestUidConverters;
using IIAuctionHouse.DataAccess.Exceptions;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestUidRepositories.IEachUidRepositories;

namespace IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories.ForestUidRepositories.EachUidRepositories
{
    public class ForestFirstUidRepository: IForestFirstUidRepository
    {
        private readonly MainDbContext _ctx;
        private readonly ForestUidFirstConverter _forestUidFirstConverter;

        public ForestFirstUidRepository(MainDbContext ctx, ForestUidFirstConverter forestUidFirstConverter)
        {
            _ctx = ctx ?? throw new NullReferenceException(DataAccessExceptions.NullContext);
            _forestUidFirstConverter = forestUidFirstConverter ?? throw new NullReferenceException(DataAccessExceptions.NullConverter);
        }

        public IEnumerable<ForestUidFirst> FindAll()
        {
            return _ctx.ForestUidFirstDbSet.OrderBy(sql => sql.Value).Select(f => new ForestUidFirst()
            {
                Id = f.Id,
                Value = f.Value,
            }).ToList();
        }
        
        public ForestUidFirst GetById(int id)
        {
            return _ctx.ForestUidFirstDbSet.Select(tree => new ForestUidFirst()
            {
                Id = tree.Id,
                Value = tree.Value,
            }).FirstOrDefault(tree => tree.Id == id);
        }

        public ForestUidFirst Create(ForestUidFirst forestUidFirst)
        {
            var forestUidFirstSql = _forestUidFirstConverter.Convert(forestUidFirst);
            _ctx.ForestUidFirstDbSet.Add(forestUidFirstSql);
            _ctx.SaveChanges();
            return _forestUidFirstConverter.Convert(forestUidFirstSql);
        }

        public ForestUidFirst Update(ForestUidFirst forestUidFirst)
        {
            var forestUidFirstSql = _forestUidFirstConverter.Convert(forestUidFirst);
            var check =_ctx.ForestUidFirstDbSet.SingleOrDefault(sql => sql.Id == forestUidFirst.Id);
            if (check != null)
                _ctx.ForestUidFirstDbSet.Update(forestUidFirstSql);
            else
                throw new InvalidDataException(DataAccessExceptions.NotFound);
            _ctx.SaveChanges();
            return _forestUidFirstConverter.Convert(forestUidFirstSql);
        }

        public ForestUidFirst Delete(int id)
        {
            var forestUidFirstSql = _ctx.ForestUidFirstDbSet.FirstOrDefault(forestUidFirstSql => forestUidFirstSql.Id == id);
            if (forestUidFirstSql == null) return null;
            _ctx.ForestUidFirstDbSet.Remove(forestUidFirstSql);
            _ctx.SaveChanges();
            return _forestUidFirstConverter.Convert(forestUidFirstSql);
        }

    }
}