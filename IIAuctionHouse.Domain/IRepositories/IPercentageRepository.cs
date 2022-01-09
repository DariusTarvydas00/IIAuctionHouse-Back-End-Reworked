using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Domain.IRepositories
{
    public interface IPercentageRepository
    {
        IEnumerable<Percentage> FindAll();
        Percentage Create(Percentage percentage);
        Percentage Update(Percentage percentage);
        Percentage Delete(int id);
    }
}