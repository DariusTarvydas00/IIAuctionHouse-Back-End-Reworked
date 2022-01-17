using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels;

namespace IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories
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