using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestDetailServices;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories;

namespace IIAuctionHouse.Domain.Services.ForestDetailServices
{
    public class ForestGroupService: IForestGroupService
    {
        private readonly IForestGroupRepository _forestGroupRepository;

        public ForestGroupService(IForestGroupRepository forestGroupRepository)
        {
            _forestGroupRepository = forestGroupRepository ?? throw new NullReferenceException("Forest Group Repository Cannot be null");;;
        }

        public List<ForestGroup> GetAll()
        {
            return _forestGroupRepository.FindAll().ToList();
        }

        public ForestGroup Create(ForestGroup forestGroup)
        {
            if (forestGroup == null)
                throw new InvalidDataException("Forest Group is missing some information");
            return _forestGroupRepository.Create(forestGroup);
        }
        
        public ForestGroup NewForestGroup(string name)
        {
            if (name.Any(char.IsDigit) || string.IsNullOrEmpty(name))
                throw new InvalidDataException("Incorrect Forest Group Name");
            return new ForestGroup() {Name = name};
        }
        
        public ForestGroup UpdateForestGroup(int id, string name)
        {
            if (id <1 || name.Any(char.IsDigit) || string.IsNullOrEmpty(name))
                throw new InvalidDataException("Incorrect Forest Group Name or Id");
            return new ForestGroup() {Id = id,Name = name};
        }

        public ForestGroup Update(ForestGroup forestGroup)
        {
            if (forestGroup == null)
                throw new InvalidDataException("Forest Group to update is missing some information");
            return _forestGroupRepository.Update(forestGroup);
        }

        public ForestGroup Delete(int id)
        {
            if (id < 1)
                throw new InvalidDataException("Incorrect Forest Grou Id");
            return _forestGroupRepository.Delete(id);
        }
    }
}