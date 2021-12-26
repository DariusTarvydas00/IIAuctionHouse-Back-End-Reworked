using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestService;
using IIAuctionHouse.Core.Models.Forest;
using IIAuctionHouse.Domain.IRepositories.IForestRepositories;

namespace IIAuctionHouse.Domain.Services.ForestServices
{
    public class ForestLocationService: IForestLocationService
    {
        private readonly IForestLocationRepo _forestLocationRepo;

        public ForestLocationService(IForestLocationRepo forestLocationRepo)
        {
            _forestLocationRepo = forestLocationRepo;
        }

        public List<ForestLocation> GetAll()
        {
            return _forestLocationRepo.FindAll().ToList();
        }

        public ForestLocation GetById(int id)
        {
            return _forestLocationRepo.GetById(id);
        }

        public ForestLocation Create(string forestryEnterprise)
        {
            return _forestLocationRepo.Create(forestryEnterprise);
        }

        public ForestLocation Update(ForestLocation forestLocation)
        {
            return _forestLocationRepo.Update(forestLocation);
        }

        public ForestLocation Delete(int id)
        {
            return _forestLocationRepo.Delete(id);
        }
    }
}