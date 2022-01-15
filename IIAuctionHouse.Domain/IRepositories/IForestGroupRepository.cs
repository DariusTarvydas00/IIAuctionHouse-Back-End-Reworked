using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Domain.IRepositories
{
    public interface IForestGroupRepository
    {
        IEnumerable<ForestGroup> FindAll();
        ForestGroup Create(ForestGroup forestGroup);
        ForestGroup Update(ForestGroup forestGroup);
        ForestGroup Delete(int id);
    }
}