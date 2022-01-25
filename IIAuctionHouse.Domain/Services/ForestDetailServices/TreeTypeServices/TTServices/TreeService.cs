using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestDetailServices.ITreeTypeServices.TTServices;
using IIAuctionHouse.Core.Models.ForestDetailModels.TreeTypes.TTModels;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.ITreeTypeRepositories.TTRepositories;

namespace IIAuctionHouse.Domain.Services.ForestDetailServices.TreeTypeServices.TTServices
{
    public class TreeService: ITreeService
    {
        private readonly ITreeRepository _treeRepository;

        public TreeService(ITreeRepository treeRepository)
        {
            _treeRepository = treeRepository ?? throw new NullReferenceException("Tree Repository Can Not Be Null");
        }

        public List<Tree> GetAll()
        {
            return _treeRepository.FindAll().ToList();
        }
        
        public Tree GetById(int id)
        {
            if (id < 1)
                throw new Exception("Tree Id Can Not Be Less Than 1");
            return _treeRepository.GetById(id);
        }

        public Tree NewTree(int id, string treeName)
        {
            if (id < 1)
                throw new Exception("Tree Id Can Not Be Less Than 1");
            if (treeName.Any(char.IsDigit) || string.IsNullOrEmpty(treeName))
            {
                throw new InvalidDataException("Incorrect Tree Name");
            }
            return new Tree()
            {
                Id = id,
                Name = treeName
            };
        }

        public Tree NewTree(string treeName)
        {
            if (treeName.Any(char.IsDigit) || string.IsNullOrEmpty(treeName))
            {
                throw new InvalidDataException("Incorrect Tree Name");
            }
            return new Tree()
            {
                Name = treeName
            };
        }

        public Tree Create(Tree tree)
        {
            if (tree == null)
                throw new InvalidDataException("Tree Cannot Be Null");
            if (tree.Name.Any(char.IsDigit) || string.IsNullOrEmpty(tree.Name))
            {
                throw new InvalidDataException("Incorrect Tree Name");
            }
            return _treeRepository.Create(tree);
        }

        public Tree Update(Tree tree)
        {
            if (tree == null)
                throw new InvalidDataException("Tree Cannot Be Null");
            if (tree.Id < 1)
                throw new Exception("Tree Id Can Not Be Less Than 1");
            if (tree.Name.Any(char.IsDigit) || string.IsNullOrEmpty(tree.Name))
            {
                throw new InvalidDataException("Incorrect Tree Name");
            }
            return _treeRepository.Update(tree);
        }
        
        public Tree Delete(int id)
        {
            if (id < 1)
                throw new Exception("Tree Id Can Not Be Less Than 1");
            return _treeRepository.Delete(id);
        }
        
    }
}