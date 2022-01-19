using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IPlotDetailServices.ITreeTypeServices;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IPlotDetailRepositories.ITreeTypeRepositories;
using IIAuctionHouse.Domain.ServiceExceptions;
using IIAuctionHouse.Domain.Validators.ForestDetailsValidators.PlotDetailsValidators.TreeTypeValidators;

namespace IIAuctionHouse.Domain.Services.ForestDetailServices.PlotServices.TreeTypeServices
{
    public class TreeService: ITreeService
    {
        private readonly ITreeRepository _treeRepository;
        private readonly TreeValidator _treeValidator;

        public TreeService(ITreeRepository treeRepository, TreeValidator treeValidator)
        {
            _treeRepository = treeRepository ?? throw new NullReferenceException(ServicesExceptions.NullRepository);
            _treeValidator = treeValidator ?? throw new NullReferenceException(ServicesExceptions.NullValidator);
        }

        public List<Tree> GetAll()
        {
            return _treeRepository.FindAll().ToList();
        }
        
        public Tree NewTree(string name)
        {
            _treeValidator.ValidateValue(name);
            return new Tree()
            {
                Name = name
            };
        }

        public Tree NewTree(int id, string name)
        {
            _treeValidator.ValidateValue(name);
            _treeValidator.ValidateNumber(id);
            return new Tree()
            {
                Id = id,
                Name = name
            };
        }

        public Tree Create(Tree tree)
        {
            _treeValidator.DefaultValidation(tree);
            return _treeRepository.Create(tree);
        }

        public Tree Update(Tree tree)
        {
            _treeValidator.DefaultValidation(tree);
            return _treeRepository.Update(tree);
        }

        public Tree Delete(int id)
        {
            _treeValidator.ValidateNumber(id);
            return _treeRepository.Delete(id);
        }
    }
}