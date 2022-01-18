using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestDetailServices;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories;
using IIAuctionHouse.Domain.ServiceExceptions;

namespace IIAuctionHouse.Domain.Services.ForestDetailServices
{
    public class ForestGroupService: IForestGroupService
    {
        private readonly IForestGroupRepository _forestGroupRepository;

        public ForestGroupService(IForestGroupRepository forestGroupRepository)
        {
            _forestGroupRepository = forestGroupRepository ?? throw new NullReferenceException(ServicesExceptions.NullRepository);
        }

        public List<ForestGroup> GetAll()
        {
            return _forestGroupRepository.FindAll().ToList();
        }

        public ForestGroup Create(ForestGroup forestGroup)
        {
            if (forestGroup == null )
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            return _forestGroupRepository.Create(forestGroup);
        }
        
        public ForestGroup NewForestGroup(string name)
        {
            if (name.Any(char.IsDigit) || string.IsNullOrEmpty(name))
                throw new InvalidDataException(ServicesExceptions.InvalidName);
            return new ForestGroup() {Name = name};
        }
        
        public ForestGroup UpdateForestGroup(int id, string name)
        {
            if (id <1 || name.Any(char.IsDigit) || string.IsNullOrEmpty(name))
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            return new ForestGroup() {Id = id,Name = name};
        }

        public ForestGroup Update(ForestGroup forestGroup)
        {
            if (forestGroup == null)
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            return _forestGroupRepository.Update(forestGroup);
        }

        public ForestGroup Delete(int id)
        {
            if (id < 1)
                throw new InvalidDataException(ServicesExceptions.InvalidId);
            return _forestGroupRepository.Delete(id);
        }
    }
}