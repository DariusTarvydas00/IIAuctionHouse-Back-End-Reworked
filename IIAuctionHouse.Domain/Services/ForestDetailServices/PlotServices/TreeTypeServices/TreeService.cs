using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IPlotDetailServices.ITreeTypeServices;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IPlotDetailRepositories.ITreeTypeRepositories;
using IIAuctionHouse.Domain.ServiceExceptions;

namespace IIAuctionHouse.Domain.Services.ForestDetailServices.PlotServices.TreeTypeServices
{
    public class TreeService: ITreeService
    {
        private readonly ITreeRepository _treeRepository;

        public TreeService(ITreeRepository treeRepository)
        {
            _treeRepository = treeRepository ?? throw new NullReferenceException(ServicesExceptions.NullRepository);
        }

        public List<Tree> GetAll()
        {
            return _treeRepository.FindAll().ToList();
        }

        public Tree Create(Tree tree)
        {
            if (tree == null)
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            return _treeRepository.Create(tree);
        }
        
        public Tree NewTree(string name)
        {
            if (name.Any(char.IsDigit) || string.IsNullOrEmpty(name))
                throw new InvalidDataException(ServicesExceptions.InvalidName);
            return new Tree() {Name = name};
        }
        
        public Tree UpdateTree(int id, string name)
        {
            if (name.Any(char.IsDigit) || string.IsNullOrEmpty(name))
                throw new InvalidDataException(ServicesExceptions.InvalidName);
            if (id < 1)
                throw new InvalidDataException(ServicesExceptions.InvalidId);
            return new Tree() {Id = id,Name = name};
        }

        public Tree Update(Tree tree)
        {
            if (tree == null)
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            return _treeRepository.Update(tree);
        }

        public Tree Delete(int id)
        {
            if (id < 1)
                throw new InvalidDataException(ServicesExceptions.InvalidId);
            return _treeRepository.Delete(id);
        }
    }
}