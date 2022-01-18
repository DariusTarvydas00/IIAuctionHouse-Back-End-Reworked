﻿using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities;
using IIAuctionHouse.DataAccess.Exceptions;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories;

namespace IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories
{
    public class ForestEnterpriseRepository: IForestEnterpriseRepository
    {
        private readonly MainDbContext _ctx;

        public ForestEnterpriseRepository(MainDbContext ctx)
        {
            _ctx = ctx ?? throw new NullReferenceException(DataAccessExceptions.NullContext);
        }

        public IEnumerable<ForestryEnterprise> FindAll()
        {
            return _ctx.ForestryEnterpriseDbSet.Select(forestEnterprise => new ForestryEnterprise()
            {
                Id = forestEnterprise.Id,
                Name = forestEnterprise.Name,
            }).ToList();
        }

        public ForestryEnterprise GetById(int id)
        {
            var entity = _ctx.ForestryEnterpriseDbSet.Select(forestEnterprise => new ForestryEnterprise()
            {
                Id = forestEnterprise.Id,
                Name = forestEnterprise.Name,
            }).FirstOrDefault(type => type.Id == id);

            return new ForestryEnterprise()
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }

        public ForestryEnterprise Create(ForestryEnterprise forestEnterprise)
        {
            
            var entity = _ctx.ForestryEnterpriseDbSet.Add(new ForestryEnterpriseSql()
            {
                Id = forestEnterprise.Id,
                Name = forestEnterprise.Name,
            }).Entity;
            _ctx.SaveChanges();
            return new ForestryEnterprise()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public ForestryEnterprise Update(ForestryEnterprise forestEnterprise)
        {
            var entity = _ctx.ForestryEnterpriseDbSet.Update(new ForestryEnterpriseSql()
            {
                Id = forestEnterprise.Id,
                Name = forestEnterprise.Name
            }).Entity;
            _ctx.SaveChanges();
            return new ForestryEnterprise()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public ForestryEnterprise Delete(int id)
        {
            var entity = _ctx.ForestryEnterpriseDbSet.FirstOrDefault(treeType => treeType.Id == id);
            if (entity != null) _ctx.ForestryEnterpriseDbSet.Remove(entity);
            _ctx.SaveChanges();
            return entity != null ? new ForestryEnterprise()
            {
                Id = entity.Id,
                Name = entity.Name,
            }: null;
        }

    
    }
}