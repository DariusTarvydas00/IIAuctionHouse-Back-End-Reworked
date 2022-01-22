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
            CheckId(id);
            return _forestryEnterpriseRepository.GetById(id);
        }

        public ForestryEnterprise Create(ForestryEnterprise forestryEnterprise)
        {
            NewFEnterprise(forestryEnterprise);
            return _forestryEnterpriseRepository.Create(forestryEnterprise);
        }

        public ForestryEnterprise Update(int id, ForestryEnterprise forestEnterprise)
        {
            UpdateFEnterprise(id, forestEnterprise);
            return _forestryEnterpriseRepository.Update(forestEnterprise);
        }

        public ForestryEnterprise Delete(int id)
        {
            if (id < 1)
                throw new InvalidDataException("");
            return _forestryEnterpriseRepository.Delete(id);
        }
        
        
        private void UpdateFEnterprise(int id, ForestryEnterprise forestryEnterprise)
        {
            if (forestryEnterprise == null)
                throw new InvalidDataException("Forestry Enterprise Cannot Be Null");
            CheckId(id);
            CheckId(forestryEnterprise.Id);
            if (id != forestryEnterprise.Id)
                throw new Exception("Id Does Not Match");
            if (forestryEnterprise.Name.Any(char.IsDigit) || string.IsNullOrEmpty(forestryEnterprise.Name))
            {
                throw new InvalidDataException("Incorrect Forestry Enterprise Name");
            }
            
        }
        
        private void NewFEnterprise(ForestryEnterprise forestryEnterprise)
        {
            if (forestryEnterprise == null)
                throw new InvalidDataException("Tree Cannot Be Null");
            if (forestryEnterprise.Name.Any(char.IsDigit) || string.IsNullOrEmpty(forestryEnterprise.Name))
            {
                throw new InvalidDataException("Incorrect Forestry Enterprise Name");
            }
            
        }
        
        private void CheckId(int id)
        {
            if (id < 1)
                throw new Exception("Forestry Enterprise Id Can Not Be Less Than 1");
        }
    }
}