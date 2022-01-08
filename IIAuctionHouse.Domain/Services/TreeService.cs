using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.Domain.Services
{
    public class TreeService: ITreeService
    {
        private readonly ITreeRepository _treeRepository;

        public TreeService(ITreeRepository treeRepository)
        {
            _treeRepository = treeRepository ?? throw new NullReferenceException("Tree Repository Cannot be null");;;
        }

        public List<Tree> GetAll()
        {
            return _treeRepository.FindAll().ToList();
        }

        public Tree Create(Tree tree)
        {
            if (tree == null)
                throw new InvalidDataException("Tree is missing some information");
            return _treeRepository.Create(tree);
        }
        
        public Tree NewTreeType(string name)
        {
            if (name.Any(char.IsDigit) || string.IsNullOrEmpty(name))
                throw new InvalidDataException("Incorrect Tree Name");
            return new Tree() {Name = name};
        }

        public Tree Update(Tree tree)
        {
            if (tree == null)
                throw new InvalidDataException("Tree to update is missing some information");
            return _treeRepository.Update(tree);
        }

        public Tree Delete(int id)
        {
            if (id < 1)
                throw new InvalidDataException("Incorrect Tree Id");
            return _treeRepository.Delete(id);
        }
    }
}