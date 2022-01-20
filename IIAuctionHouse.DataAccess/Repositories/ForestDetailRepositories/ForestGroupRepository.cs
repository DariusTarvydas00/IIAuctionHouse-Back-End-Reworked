using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.DataAccess.Converters.ForestDetailConverters;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities;
using IIAuctionHouse.DataAccess.Exceptions;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories;
using Microsoft.EntityFrameworkCore;

namespace IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories
{
    public class ForestGroupRepository: IForestGroupRepository
    {
        private readonly MainDbContext _ctx;
        private readonly ForestGroupConverter _forestGroupConverter;

        public ForestGroupRepository(MainDbContext ctx, ForestGroupConverter forestGroupConverter)
        {
            _ctx = ctx ?? throw new NullReferenceException(DataAccessExceptions.NullContext);
            _forestGroupConverter = forestGroupConverter ?? throw new NullReferenceException(DataAccessExceptions.NullContext);
        }

        public IEnumerable<ForestGroup> FindAll()
        {
            return _ctx.ForestGroupDbSet.OrderBy(sql => sql.Name).Select(forestGroup => new ForestGroup()
            {
                Id = forestGroup.Id,
                Name = forestGroup.Name,
            }).ToList();
        }
        
        public ForestGroup GetById(int id)
        {
            var forestGroupList = _ctx.ForestGroupDbSet
                .FirstOrDefault(sql => sql.Id == id);
            return forestGroupList != null ? _forestGroupConverter.Convert(forestGroupList) : null;
        }
        
        public ForestGroup GetByIdIncludeDetails(int id)
        {
            var forestGroupList = _ctx.ForestGroupDbSet
                .Include(sql => sql.ForestSqls)
                .ThenInclude(sql => sql.ForestryEnterpriseSql)
                .Include(sql => sql.ForestSqls)
                .ThenInclude(sql => sql.ForestLocationSql)
                .FirstOrDefault(sql => sql.Id == id);
            return forestGroupList != null ? _forestGroupConverter.Convert(forestGroupList) : null;
        }

        public ForestGroup Create(ForestGroup forestGroup)
        {
            var forestGroupSql = _forestGroupConverter.Convert(forestGroup);
            _ctx.ForestGroupDbSet.Add(forestGroupSql);
            _ctx.SaveChanges();
            return _forestGroupConverter.Convert(forestGroupSql);
        }

        public ForestGroup Update(ForestGroup forestGroup)
        {
            _ctx.ForestGroupDbSet.Update(_forestGroupConverter.Convert(forestGroup));
            _ctx.SaveChanges();
            return forestGroup;
        }

        public ForestGroup Delete(int id)
        {
            var forestGroupSql = _ctx.ForestGroupDbSet.FirstOrDefault(fg => fg.Id == id);
            if (forestGroupSql == null) 
                throw new InvalidDataException(DataAccessExceptions.NotFound);
            _ctx.ForestGroupDbSet.Remove(forestGroupSql); 
            _ctx.SaveChanges();
            return _forestGroupConverter.Convert(forestGroupSql);
        }

    }
}