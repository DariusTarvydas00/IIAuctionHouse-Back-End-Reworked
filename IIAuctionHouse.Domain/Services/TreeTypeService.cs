using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.Domain.Services
{
    public class TreeTypeService: ITreeTypeService
    {
        private readonly ITreeTypeRepository _treeTypeRepository;

        public TreeTypeService(ITreeTypeRepository treeTypeRepository)
        {
            _treeTypeRepository = treeTypeRepository;
        }

        public List<TreeType> GetAll()
        {
            return _treeTypeRepository.FindAll().ToList();
        }

        public TreeType GetById(int id)
        {
            return _treeTypeRepository.GetById(id);
        }

        public TreeType NewTreeType(string name, int percentage)
        {
            throw new System.NotImplementedException();
        }

        public TreeType NewTreeType(string newTreeTypeName, Percentage newTreeTypePercentage)
        {
            var newTreeType = new TreeType()
            {
                Name = newTreeTypeName,
                Percentage = newTreeTypePercentage
            };
            return newTreeType;
        }

        public TreeType Create(TreeType treeType)
        {
            return _treeTypeRepository.Create(treeType);
        }

        public TreeType Update(TreeType treeType)
        {
            return _treeTypeRepository.Update(treeType);
        }

        public TreeType Delete(int id)
        {
            return _treeTypeRepository.Delete(id);
        }
    }
}