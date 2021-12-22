using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Domain.IRepositories
{
    public interface IProprietaryRepository
    {
        IEnumerable<Proprietary> GetAll();

        public Proprietary GetById(int id);
    }
}