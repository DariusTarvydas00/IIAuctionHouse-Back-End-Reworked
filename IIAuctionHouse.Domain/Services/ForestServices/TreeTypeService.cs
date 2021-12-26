using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestService;
using IIAuctionHouse.Core.Models.Forest;
using IIAuctionHouse.Domain.IRepositories.IForestRepositories;

namespace IIAuctionHouse.Domain.Services.ForestServices
{
    public class TreeTypeService: ITreeTypeService
    {
        private readonly ITreeTypeRepo _treeTypeRepo;

        public TreeTypeService(ITreeTypeRepo treeTypeRepo)
        {
            _treeTypeRepo = treeTypeRepo;
        }

        public List<TreeType> GetAll()
        {
            return _treeTypeRepo.FindAll().ToList();
        }

        public TreeType GetById(int id)
        {
            return _treeTypeRepo.GetById(id);
        }

        public TreeType Create(string treeType)
        {
            return _treeTypeRepo.Create(treeType);
        }

        public TreeType Update(TreeType treeType)
        {
            return _treeTypeRepo.Update(treeType);
        }

        public TreeType Delete(int id)
        {
            return _treeTypeRepo.Delete(id);
        }
    }
}