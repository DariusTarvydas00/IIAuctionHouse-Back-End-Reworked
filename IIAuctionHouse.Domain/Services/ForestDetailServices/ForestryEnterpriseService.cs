using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestDetailServices;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories;

namespace IIAuctionHouse.Domain.Services.ForestDetailServices
{
    public class ForestryEnterpriseService: IForestEnterpriseService
    {
        private readonly IForestryEnterpriseRepository _forestryEnterpriseRepository;

        public ForestryEnterpriseService(IForestryEnterpriseRepository forestryEnterpriseRepository)
        {
            _forestryEnterpriseRepository = forestryEnterpriseRepository ?? throw new  NullReferenceException("Forestry Enterprise Repository Can Not Be Null");
        }

        public List<ForestryEnterprise> GetAll()
        {
            return _forestryEnterpriseRepository.FindAll().ToList();
        }
        
        public ForestryEnterprise GetById(int id)
        {
            if (id < 1)
                throw new Exception("Forestry Enterprise Id Can Not Be Less Than 1");
            var forestryEnterprise = _forestryEnterpriseRepository.GetById(id);
            if (forestryEnterprise != null)
            {
                return forestryEnterprise;
            }
            throw new Exception("Forestry Enterprise Not Found");
        }

        public ForestryEnterprise Create(ForestryEnterprise forestryEnterprise)
        {
            ValidateName(forestryEnterprise.Name);
            return _forestryEnterpriseRepository.Create(forestryEnterprise);
        }

        private void ValidateName(string name)
        {
            if (name == null)
                throw new InvalidDataException("Forestry Enterprise Cannot Be Null");
            if (name.Any(char.IsDigit) || string.IsNullOrEmpty(name))
            {
                throw new InvalidDataException("Incorrect Forestry Enterprise Name");
            }
        }

        public ForestryEnterprise NewForestryEnterprise(int id, string name)
        {
            if (id < 1)
                throw new Exception("Forestry Enterprise Id Can Not Be Less Than 1");
            ValidateName(name);
            return new ForestryEnterprise()
            {
                Id = id,
                Name = name
            };
        }
        
        public ForestryEnterprise NewForestryEnterprise(string name)
        {
            ValidateName(name);
            return new ForestryEnterprise()
            {
                Name = name
            };
        }

        public ForestryEnterprise Update(ForestryEnterprise forestryEnterprise)
        {
            if (forestryEnterprise.Id < 1)
                throw new Exception("Forestry Enterprise Id Can Not Be Less Than 1");
            ValidateName(forestryEnterprise.Name);
            return _forestryEnterpriseRepository.Update(forestryEnterprise);
        }

        public ForestryEnterprise Delete(int id)
        {
            if (id < 1)
                throw new InvalidDataException("Forestry Enterprise Id Can Not Be Less Than 1");
            return _forestryEnterpriseRepository.Delete(id);
        }

    }
}