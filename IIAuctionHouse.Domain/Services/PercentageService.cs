using System;
using System.Collections.Generic;
using System.IO;
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
            _percentageRepository = percentageRepository ?? throw new NullReferenceException("Percentage Repository Cannot be null");
        }

        public List<Percentage> GetAll()
        {
            return _percentageRepository.FindAll().ToList();
        }

        public Percentage NewPercentage(int value)
        {
            if (value < 1)
                throw new InvalidDataException("Incorrect Percentage Value");
            return new Percentage()
            {
                Value = value
            };
        }

        public Percentage Create(Percentage percentage)
        {
            if (percentage == null)
                throw new InvalidDataException("New Percentage is missing some information");
            return _percentageRepository.Create(percentage);
        }

        public Percentage Update(Percentage percentage)
        {
            if (percentage == null)
                throw new InvalidDataException("Percentage to update is missing some information");
            return _percentageRepository.Update(percentage);
        }

        public Percentage Delete(int id)
        {
            if (id < 1 || string.IsNullOrEmpty(id.ToString()))
                throw new InvalidDataException("Incorrect Percentage Id");
            return _percentageRepository.Delete(id);
        }
    }
}