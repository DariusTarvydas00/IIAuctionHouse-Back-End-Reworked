using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IPlotDetailServices.ITreeTypeServices;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IPlotDetailRepositories.ITreeTypeRepositories;
using IIAuctionHouse.Domain.ServiceExceptions;

namespace IIAuctionHouse.Domain.Services.ForestDetailServices.PlotServices.TreeTypeServices
{
    public class PercentageService: IPercentageService
    {
        private readonly IPercentageRepository _percentageRepository;

        public PercentageService(IPercentageRepository percentageRepository)
        {
            _percentageRepository = percentageRepository ?? throw new NullReferenceException(ServicesExceptions.NullRepository);
        }

        public List<Percentage> GetAll()
        {
            return _percentageRepository.FindAll().ToList();
        }

        public Percentage NewPercentage(int value)
        {
            if (value < 1)
                throw new InvalidDataException(ServicesExceptions.InvalidValue);

            return new Percentage()
            {
                Value = value
            };
        }

        public Percentage Create(Percentage percentage)
        {
            if (percentage == null)
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            return _percentageRepository.Create(percentage);
        }

        public Percentage Update(Percentage percentage)
        {
            if (percentage == null)
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            return _percentageRepository.Update(percentage);
        }

        public Percentage UpdatePercentage(int id, int percentage)
        {
            if (id < 1 || percentage < 1)
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            return new Percentage() {Id = id, Value = percentage};
        }

        public Percentage Delete(int id)
        {
            if (id < 1)
                throw new InvalidDataException(ServicesExceptions.InvalidId);
            return _percentageRepository.Delete(id);
        }
    }
}