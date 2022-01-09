using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Domain.IRepositories
{
    public interface IForestEnterpriseRepository
    {
        IEnumerable<ForestryEnterprise> FindAll();
        ForestryEnterprise GetById(int id);
        ForestryEnterprise Create(ForestryEnterprise plot);
        ForestryEnterprise Update(ForestryEnterprise plot);
        ForestryEnterprise Delete(int id);
    }
}