using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestService;
using IIAuctionHouse.Core.Models.Forest;
using IIAuctionHouse.Domain.IRepositories.IForestRepositories;

namespace IIAuctionHouse.Domain.Services.ForestServices
{
    public class TreeGroupService: ITreeGroupService
    {
        private readonly ITreeGroupRepo _treeGroupRepo;

        public TreeGroupService(ITreeGroupRepo treeGroupRepo)
        {
            _treeGroupRepo = treeGroupRepo;
        }

        public List<TreeGroup> GetAll()
        {
            return _treeGroupRepo.FindAll().ToList();
        }

        public TreeGroup GetById(int id)
        {
            return _treeGroupRepo.GetById(id);
        }

        public TreeGroup Create(string treeGroup)
        {
            return _treeGroupRepo.Create(treeGroup);
        }

        public TreeGroup Update(TreeGroup treeGroup)
        {
            return _treeGroupRepo.Update(treeGroup);
        }

        public TreeGroup Delete(int id)
        {
            return _treeGroupRepo.Delete(id);
        }
    }
}