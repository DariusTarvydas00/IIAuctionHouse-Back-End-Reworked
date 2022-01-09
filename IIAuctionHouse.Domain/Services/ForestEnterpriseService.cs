using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.Domain.Services
{
    public class ForestEnterpriseService: IForestEnterpriseService
    {
        private readonly IForestEnterpriseRepository _forestEnterpriseRepository;

        public ForestEnterpriseService(IForestEnterpriseRepository forestEnterpriseRepository)
        {
            _forestEnterpriseRepository = forestEnterpriseRepository ?? throw new NullReferenceException("Forest Enterprise Repository Cannot be null");
        }

        public List<ForestryEnterprise> GetAll()
        {
            return _forestEnterpriseRepository.FindAll().ToList();
        }

        public ForestryEnterprise NewForestEnterprise(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new InvalidDataException("Incorrect Forest Enterprise Value");
            return new ForestryEnterprise()
            {
                Name = value
            };
        }
        
        public ForestryEnterprise GetById(int id)
        {
            return _forestEnterpriseRepository.GetById(id);
        }

        public ForestryEnterprise Create(ForestryEnterprise forestryEnterprise)
        {
            if (forestryEnterprise == null)
                throw new InvalidDataException("New Percentage is missing some information");
            return _forestEnterpriseRepository.Create(forestryEnterprise);
        }

        public ForestryEnterprise Update(ForestryEnterprise forestryEnterprise)
        {
            if (forestryEnterprise == null)
                throw new InvalidDataException("Forest Enterprise to update is missing some information");
            return _forestEnterpriseRepository.Update(forestryEnterprise);
        }

        public ForestryEnterprise Delete(int id)
        {
            if (id < 1)
                throw new InvalidDataException("Incorrect Forest Enterprise Id");
            return _forestEnterpriseRepository.Delete(id);
        }
    }
}