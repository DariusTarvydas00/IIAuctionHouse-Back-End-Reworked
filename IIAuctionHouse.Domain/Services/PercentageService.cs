using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.Domain.Services
{
    public class PercentageService: IPercentageService
    {
        private readonly IPercentageRepository _percentageRepository;

        public PercentageService(IPercentageRepository percentageRepository)
        {
            _percentageRepository = percentageRepository;
        }

        public List<Percentage> GetAll()
        {
            return _percentageRepository.FindAll().ToList();
        }

        public Percentage GetById(int id)
        {
            return _percentageRepository.GetById(id);
        }

        public Percentage NewPercentage(int percentage)
        {
            return new Percentage()
            {
                PercentageValue = percentage
            };
        }

        public Percentage Create(Percentage percentage)
        {
            return _percentageRepository.Create(percentage);
        }

        public Percentage Update(Percentage percentage)
        {
            return _percentageRepository.Update(percentage);
        }

        public Percentage Delete(int id)
        {
            return _percentageRepository.Delete(id);
        }
    }
}