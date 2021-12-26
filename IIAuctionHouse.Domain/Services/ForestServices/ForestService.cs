using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestService;
using IIAuctionHouse.Core.Models.Forest;
using IIAuctionHouse.Domain.IRepositories.IForestRepositories;

namespace IIAuctionHouse.Domain.Services.ForestServices
{
    public class ForestService: IForestService
    {
        private readonly IForestRepo _forestRepo;

        public ForestService(IForestRepo forestRepo)
        {
            _forestRepo = forestRepo;
        }

        public List<Forest> GetAll()
        {
            return _forestRepo.FindAll().ToList();
        }

        public Forest GetById(int id)
        {
            return _forestRepo.GetById(id);
        }

        public Forest NewForest(TreeGroup treeGroup, TreeType treeType, ForestLocation forestLocation)
        {
            return new Forest()
            {
                ForestLocation = forestLocation,
                TreeGroup = treeGroup,
                TreeType = treeType
            };
        }

        public Forest Create(Forest forest)
        {
            var newForest = NewForest(forest.TreeGroup, forest.TreeType, forest.ForestLocation);
            return _forestRepo.Create(newForest);
        }

        public Forest Update(Forest forestLocation)
        {
            return _forestRepo.Update(forestLocation);
        }

        public Forest Delete(int id)
        {
            return _forestRepo.Delete(id);
        }
    }
}