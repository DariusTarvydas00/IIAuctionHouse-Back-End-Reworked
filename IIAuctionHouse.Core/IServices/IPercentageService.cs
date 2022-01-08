using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.IServices
{
    public interface IPercentageService
    {
        List<Percentage> GetAll();
        Percentage NewPercentage(int percentage);
        Percentage Create(Percentage percentage);
        Percentage Update(Percentage percentage);
        Percentage Delete(int id);
    }
}