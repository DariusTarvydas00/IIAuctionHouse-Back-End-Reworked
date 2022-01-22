using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.TreeTypes.TTModels;

namespace IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.ITreeTypeRepositories.TTRepositories
{
    public interface IPercentageRepository
    {
        IEnumerable<Percentage> FindAll();
        Percentage GetById(int id);
    }
}