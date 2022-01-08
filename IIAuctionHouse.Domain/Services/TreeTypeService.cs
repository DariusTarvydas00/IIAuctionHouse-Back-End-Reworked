using System.Collections.Generic;
using System.IO;
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
            if (id != null || id > 1)
                return _treeTypeRepository.GetById(id);
            throw new InvalidDataException("Incorrect Tree Type Id");
        }

        public TreeType Create(TreeType treeType)
        {
            if (treeType != null) 
                return _treeTypeRepository.Create(treeType);
            throw new InvalidDataException("Tree Type is missing some information");
        }
        
        public TreeType NewTreeType(Tree treeType, Percentage percentage)
        {
            if (treeType == null || percentage == null)
                throw new InvalidDataException("Incorrect Tree Type Name");
            return new TreeType()
            {
                Tree = new Tree()
                {
                    Id = treeType.Id,
                    Name = treeType.Name
                },
                Percentage = new Percentage()
                {
                    Id = percentage.Id,
                    Value = percentage.Value
                }
            };
        }

        public TreeType Update(TreeType treeType)
        {
            if (treeType != null) 
                return _treeTypeRepository.Update(treeType);
            throw new InvalidDataException("Tree Type to update is missing some information");
        }

        public TreeType Delete(int id)
        {
            if (id == null || id < 1)
                throw new InvalidDataException("Incorrect Tree Type Id");
            return _treeTypeRepository.Delete(id);
        }
    }
}