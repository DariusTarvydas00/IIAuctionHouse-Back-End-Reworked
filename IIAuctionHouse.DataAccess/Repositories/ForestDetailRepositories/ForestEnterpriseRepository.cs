using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.DataAccess.Converters.ForestDetailConverters;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.DataAccess.Exceptions;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories;
using Microsoft.EntityFrameworkCore;

namespace IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories
{
    public class ForestEnterpriseRepository: IForestEnterpriseRepository
    {
        private readonly MainDbContext _ctx;
        private readonly ForestryEnterpriseConverter _forestryEnterpriseConverter;

        public ForestEnterpriseRepository(
            MainDbContext ctx, 
            ForestryEnterpriseConverter forestryEnterpriseConverter)
        {
            _ctx = ctx ?? throw new NullReferenceException(DataAccessExceptions.NullContext);
            _forestryEnterpriseConverter = forestryEnterpriseConverter ?? throw new NullReferenceException(DataAccessExceptions.NullConverter);
        }

        public IEnumerable<ForestryEnterprise> FindAll()
        {
            return _ctx.ForestryEnterpriseDbSet.Select(forestEnterprise => new ForestryEnterprise()
            {
                Id = forestEnterprise.Id,
                Name = forestEnterprise.Name,
                Forests = forestEnterprise.ForestSqls.Select(sql => new Forest()
                {
                    ForestLocation = new ForestLocation()
                    {
                        Id = sql.ForestLocationSql.Id,
                        GeoLocationX = sql.ForestLocationSql.GeoLocationX,
                        GeoLocationY = sql.ForestLocationSql.GeoLocationY
                    }
                }).ToList()
            }).ToList();
        }
        
        public ForestryEnterprise GetById(int id)
        {
            var forestList = _ctx.ForestryEnterpriseDbSet
                .FirstOrDefault(sql => sql.Id == id);
            return forestList != null ? _forestryEnterpriseConverter.Convert(forestList) : null;
        }

        public ForestryEnterprise GetByIdIncludeDetails(int id)
        {
            var forestList = _ctx.ForestryEnterpriseDbSet
                .Include(sql => sql.ForestSqls)
                .ThenInclude(sql => sql.ForestGroupSql)
                .Include(sql => sql.ForestSqls)
                .ThenInclude(sql => sql.ForestLocationSql)
                .FirstOrDefault(sql => sql.Id == id);
            return forestList != null ? _forestryEnterpriseConverter.Convert(forestList) : null;
        }

        public ForestryEnterprise Create(ForestryEnterprise forestEnterprise)
        {
            var newFeForestryEnterpriseSql = _forestryEnterpriseConverter.Convert(forestEnterprise);
            _ctx.ForestryEnterpriseDbSet.Add(newFeForestryEnterpriseSql);
            _ctx.SaveChanges();
            return _forestryEnterpriseConverter.Convert(newFeForestryEnterpriseSql);
        }

        public ForestryEnterprise Update(ForestryEnterprise forestryEnterprise)
        {
            _ctx.ForestryEnterpriseDbSet.Update(_forestryEnterpriseConverter.Convert(forestryEnterprise));
            _ctx.SaveChanges();
            return forestryEnterprise;
        }

        public ForestryEnterprise Delete(int id)
        {
            var forestryEnterpriseSql = _ctx.ForestryEnterpriseDbSet.FirstOrDefault(fe => fe.Id == id);
            if (forestryEnterpriseSql == null) 
                throw new InvalidDataException(DataAccessExceptions.NotFound);
            _ctx.ForestryEnterpriseDbSet.Remove(forestryEnterpriseSql); 
            _ctx.SaveChanges();
            return _forestryEnterpriseConverter.Convert(forestryEnterpriseSql);

        }
    }
}