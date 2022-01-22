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
            CheckId(id);
            return _treeRepository.GetById(id);
        }

        public Tree Create(Tree tree)
        {
            NewTree(tree);
            return _treeRepository.Create(tree);
        }

        public Tree Update(int id, Tree tree)
        {
            UpdateTree(id, tree);
            return _treeRepository.Update(tree);
        }
        
        public Tree Delete(int id)
        {
            CheckId(id);
            return _treeRepository.Delete(id);
        }

        private void NewTree(Tree tree)
        {
            if (tree == null)
                throw new InvalidDataException("Tree Cannot Be Null");
            if (tree.Name.Any(char.IsDigit) || string.IsNullOrEmpty(tree.Name))
            {
                throw new InvalidDataException("Incorrect Tree Name");
            }
            
        }
        
        private void UpdateTree(int id, Tree tree)
        {
            if (tree == null)
                throw new InvalidDataException("Tree Cannot Be Null");
            CheckId(id);
            CheckId(tree.Id);
            if (id != tree.Id)
                throw new Exception("Id Does Not Match");
            if (tree.Name.Any(char.IsDigit) || string.IsNullOrEmpty(tree.Name))
            {
                throw new InvalidDataException("Incorrect Tree Name");
            }
            
        }
        
        private void CheckId(int id)
        {
            if (id < 1)
                throw new Exception("Tree Id Can Not Be Less Than 1");
        }
    }
}