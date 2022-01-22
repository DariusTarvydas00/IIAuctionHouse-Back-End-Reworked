using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels;

namespace IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories
{
    public interface IForestryEnterpriseRepository
    {
        IEnumerable<ForestryEnterprise> FindAll();
        ForestryEnterprise GetById(int id);
        ForestryEnterprise Create(ForestryEnterprise forestryEnterprise);
        ForestryEnterprise Update(ForestryEnterprise forestryEnterprise);
        ForestryEnterprise Delete(int id);
    }
}