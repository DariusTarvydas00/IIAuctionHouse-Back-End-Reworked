using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.TreeTypes.TTModels;

namespace IIAuctionHouse.Core.IServices.IForestDetailServices.ITreeTypeServices.TTServices
{
    public interface IPercentageService
    {
        List<Percentage> GetAll();
        Percentage GetById(int percentageId);
    }
}