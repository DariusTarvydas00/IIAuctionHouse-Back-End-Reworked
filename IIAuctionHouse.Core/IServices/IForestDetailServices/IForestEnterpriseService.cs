using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels;

namespace IIAuctionHouse.Core.IServices.IForestDetailServices
{
    public interface IForestEnterpriseService
    {
        List<ForestryEnterprise> GetAll();
        ForestryEnterprise GetById(int id);
        ForestryEnterprise Create(ForestryEnterprise forestEnterprise);
        ForestryEnterprise Update(int id, ForestryEnterprise forestEnterprise);
        ForestryEnterprise Delete(int id);
        
    }
}