using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models.Forest;
using IIAuctionHouse.DataAccess.Entities.ForestEntities;
using IIAuctionHouse.Domain.IRepositories.IForestRepositories;

namespace IIAuctionHouse.DataAccess.Repositories.ForestRepositories
{
    public class ForestLocationRepository: IForestLocationRepo
    {
        private readonly MainDbContext _ctx;

        public ForestLocationRepository(MainDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<ForestLocation> FindAll()
        {
            return _ctx.ForestLocations.Select(ae=>new ForestLocation()
            {
                Id = ae.Id,
                ForestryEnterprise = ae.ForestryEnterprise
            }).ToList();
        }

        public ForestLocation GetById(int id)
        {
            return _ctx.ForestLocations.Select(ae => new ForestLocation()
            {
                Id = ae.Id,
                ForestryEnterprise = ae.ForestryEnterprise
            }).FirstOrDefault(e => e.Id == id);
        }

        public ForestLocation Create(string forestryEnterprise)
        {
            var entity = _ctx.ForestLocations.Add(new ForestLocationEntity()
            {
                ForestryEnterprise = forestryEnterprise
            }).Entity;
            _ctx.SaveChanges();
            return new ForestLocation()
            {
                Id = entity.Id,
                ForestryEnterprise = entity.ForestryEnterprise
            };
        }

        public ForestLocation Update(ForestLocation forestLocation)
        {
            var entity = _ctx.ForestLocations.Update(new ForestLocationEntity()
            {
                Id = forestLocation.Id,
                ForestryEnterprise = forestLocation.ForestryEnterprise
            }).Entity;
            _ctx.SaveChanges();
            return new ForestLocation()
            {
                Id = entity.Id,
                ForestryEnterprise = entity.ForestryEnterprise
            };
        }

        public ForestLocation Delete(int id)
        {
            var entity = _ctx.ForestLocations.Remove(new ForestLocationEntity()
            {
                Id = id
            }).Entity;
            _ctx.SaveChanges();
            return new ForestLocation()
            {
                Id = entity.Id,
                ForestryEnterprise = entity.ForestryEnterprise
            };
        }
    }
}