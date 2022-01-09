using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.IServices
{
    public interface IForestEnterpriseService
    {
        List<ForestryEnterprise> GetAll();
        ForestryEnterprise GetById(int id);
        ForestryEnterprise NewForestEnterprise(string value);
        ForestryEnterprise Create(ForestryEnterprise forestEnterprise);
        ForestryEnterprise Update(ForestryEnterprise forestEnterprise);
        ForestryEnterprise Delete(int id);
    }
}