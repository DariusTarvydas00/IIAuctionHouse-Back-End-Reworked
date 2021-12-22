using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.Domain.Services
{
    public class ProprietaryService: IProprietaryService
    {
        private readonly IProprietaryRepository _proprietaryRepository;

        public ProprietaryService(IProprietaryRepository proprietaryRepository)
        {
            _proprietaryRepository = proprietaryRepository;
        }

        public IList<Proprietary> GetAll()
        {
            return _proprietaryRepository.GetAll().ToList();
        }

        public Proprietary GetById(int id)
        {
            return _proprietaryRepository.GetById(id);
        }
    }
}