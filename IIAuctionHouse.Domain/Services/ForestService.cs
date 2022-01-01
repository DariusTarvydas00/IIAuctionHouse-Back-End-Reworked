using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.Domain.Services
{
    public class ForestService: IForestService
    {
        private readonly IForestRepository _forestRepository;

        public ForestService(IForestRepository forestRepository)
        {
            _forestRepository = forestRepository;
        }

        public List<Forest> GetAll()
        {
            return _forestRepository.FindAll().ToList();
        }

        public Forest GetById(int id)
        {
            return _forestRepository.GetById(id);
        }

        public Forest NewForest(ForestUid forestUid, string forestGroup, string forestryEnterprise, 
            double geoLocationX, double geoLocationY, List<Plot> plots, List<Bid> bids)
        {
            var newForest = new Forest()
            {
                ForestUid = forestUid,
                ForestGroup = forestGroup,
                ForestryEnterprise = forestryEnterprise,
                GeoLocationX = geoLocationX,
                GeoLocationY = geoLocationY,
            };
            return newForest;
        }

        public Forest Create(Forest forest)
        {
            return _forestRepository.Create(forest);
        }

        public Forest Update(Forest forest)
        {
            return _forestRepository.Update(forest);
        }

        public Forest Delete(int id)
        {
            return _forestRepository.Delete(id);
        }
    }
}