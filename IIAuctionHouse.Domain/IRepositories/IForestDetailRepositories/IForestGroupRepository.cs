using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels;

namespace IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories
{
    public interface IForestGroupRepository
    {
        IEnumerable<ForestGroup> FindAll();
        ForestGroup GetByIdIncludeDetails(int id);
        ForestGroup GetById(int id);
        ForestGroup Create(ForestGroup forestGroup);
        ForestGroup Update(ForestGroup forestGroup);
        ForestGroup Delete(int id);
    }
}