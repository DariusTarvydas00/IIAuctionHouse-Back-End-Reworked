using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.IServices
{
    public interface IProprietaryService
    {
        IList<Proprietary> GetAll();
        Proprietary GetById(int id);
    }
}