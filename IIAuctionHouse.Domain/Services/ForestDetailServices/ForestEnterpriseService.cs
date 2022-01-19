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
    public class ForestEnterpriseService: IForestEnterpriseService
    {
        private readonly IForestEnterpriseRepository _forestEnterpriseRepository;

        public ForestEnterpriseService(IForestEnterpriseRepository forestEnterpriseRepository)
        {
            _forestEnterpriseRepository = forestEnterpriseRepository ?? throw new NullReferenceException(ServicesExceptions.NullRepository);
        }

        public List<ForestryEnterprise> GetAll()
        {
            return _forestEnterpriseRepository.FindAll().ToList();
        }
        
        public ForestryEnterprise GetById(int id)
        {
            if (id < 1)
                throw new InvalidDataException(ServicesExceptions.InvalidId);
            return _forestEnterpriseRepository.GetByIdIncludeDetails(id);
        }

        public ForestryEnterprise NewForestryEnterprise(int id)
        {
            if (id < 1)
                throw new InvalidDataException(ServicesExceptions.InvalidName);
            return new ForestryEnterprise()
            {
                Id = id
            };
        }

        public ForestryEnterprise NewForestryEnterprise(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Any(char.IsDigit))
                throw new InvalidDataException(ServicesExceptions.InvalidName);
            return new ForestryEnterprise()
            {
                Name = name
            };
        }

        public ForestryEnterprise NewForestryEnterprise(int id, string name)
        {
            if (string.IsNullOrEmpty(name) || name.Any(char.IsDigit))
                throw new InvalidDataException(ServicesExceptions.InvalidName);
            if (id < 1)
                throw new InvalidDataException(ServicesExceptions.InvalidId);
            return new ForestryEnterprise()
            {
                Id = id,
                Name = name
            };
        }

        public ForestryEnterprise Create(ForestryEnterprise forestryEnterprise)
        {
            if (forestryEnterprise == null)
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            return _forestEnterpriseRepository.Create(forestryEnterprise);
        }

        public ForestryEnterprise Update(ForestryEnterprise forestryEnterprise)
        {
            if (forestryEnterprise == null)
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            return _forestEnterpriseRepository.Update(forestryEnterprise);
        }

        public ForestryEnterprise Delete(int id)
        {
            if (id < 1)
                throw new InvalidDataException(ServicesExceptions.InvalidId);
            return _forestEnterpriseRepository.Delete(id);
        }
    }
}