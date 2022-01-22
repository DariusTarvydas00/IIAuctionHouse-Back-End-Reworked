using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories;
using Microsoft.EntityFrameworkCore;

namespace IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories
{
    public class ForestryEnterpriseRepository: IForestryEnterpriseRepository
    {
        private readonly MainDbContext _ctx;

        public ForestryEnterpriseRepository(
            MainDbContext ctx)
        {
            _ctx = ctx ?? throw new NullReferenceException("Context Can Not Be Null");
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
            var fEnterprise = _ctx.ForestryEnterpriseDbSet
                .FirstOrDefault(sql => sql.Id == id);
            if (fEnterprise != null)
                return new ForestryEnterprise()
                {
                    Id = fEnterprise.Id,
                    Name = fEnterprise.Name
                };
            return null;
        }

        public ForestryEnterprise Create(ForestryEnterprise forestEnterprise)
        {
            var fEnterprise = _ctx.ForestryEnterpriseDbSet.FirstOrDefault(sql => sql.Id == forestEnterprise.Id);
            if (fEnterprise != null)
                if (fEnterprise.Name.ToLower().Equals(forestEnterprise.Name.ToLower())) throw new Exception("Forestry Enterprise Name Already Exists");
            var newFe = _ctx.ForestryEnterpriseDbSet.Add(new ForestryEnterpriseSql()
            {
                Name = forestEnterprise.Name
            }).Entity;
            _ctx.SaveChanges();
            return new ForestryEnterprise()
            {
                Id = newFe.Id,
                Name = newFe.Name
            };
        }

        public ForestryEnterprise Update(ForestryEnterprise forestryEnterprise)
        {
            var fEnterprise = _ctx.ForestryEnterpriseDbSet.AsNoTracking().FirstOrDefault(sql => sql.Id == forestryEnterprise.Id);
            if (fEnterprise == null) throw new Exception("ForestryEnterprise To Update Does Not Exist");
            if (fEnterprise.Name.ToLower().Equals(forestryEnterprise.Name.ToLower())) throw new Exception("Tree Name Already Exists");
            var newFe = _ctx.ForestryEnterpriseDbSet.Update(new ForestryEnterpriseSql()
            {
                Id = forestryEnterprise.Id,
                Name = forestryEnterprise.Name
            }).Entity;
            _ctx.SaveChanges();
            return new ForestryEnterprise()
            {
                Id = newFe.Id,
                Name = newFe.Name
            };
        }

        public ForestryEnterprise Delete(int id)
        {
            try
            {
                var fEnterprise = _ctx.ForestryEnterpriseDbSet.FirstOrDefault(fe => fe.Id == id);
                if (fEnterprise == null) throw new Exception("Forestry Enterprise Not Found ");
                _ctx.ForestryEnterpriseDbSet.Remove(fEnterprise);
                _ctx.SaveChanges();
                return new ForestryEnterprise()
                {
                    Id = fEnterprise.Id,
                    Name = fEnterprise.Name
                };
            }
            catch (Exception)
            {
                throw new Exception("Forestry Enterprise Can Not be Deleted! ");
            }

        }
    }
}