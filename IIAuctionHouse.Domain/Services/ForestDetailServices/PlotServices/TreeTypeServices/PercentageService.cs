using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IPlotDetailServices.ITreeTypeServices;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IPlotDetailRepositories.ITreeTypeRepositories;
using IIAuctionHouse.Domain.ServiceExceptions;
using IIAuctionHouse.Domain.Validators.ForestDetailsValidators.PlotDetailsValidators.TreeTypeValidators;

namespace IIAuctionHouse.Domain.Services.ForestDetailServices.PlotServices.TreeTypeServices
{
    public class PercentageService: IPercentageService
    {
        private readonly IPercentageRepository _percentageRepository;
        private readonly PercentageValidator _percentageValidator;

        public PercentageService(IPercentageRepository percentageRepository, PercentageValidator percentageValidator)
        {
            _percentageRepository = percentageRepository ?? throw new NullReferenceException(ServicesExceptions.NullRepository);
            _percentageValidator = percentageValidator ?? throw new NullReferenceException(ServicesExceptions.NullValidator);
        }

        public List<Percentage> GetAll()
        {
            return _percentageRepository.FindAll().ToList();
        }

        public Percentage NewPercentage(int value)
        {
            _percentageValidator.ValidateId(value);
            return new Percentage()
            {
                Value = value
            };
        }
        
        public Percentage NewPercentage(int id, int value)
        {
            _percentageValidator.ValidateId(value);
            _percentageValidator.ValidateId(id);
            return new Percentage()
            {
                Id = id,
                Value = value
            };
        }

        public Percentage Create(Percentage percentage)
        {
            _percentageValidator.DefaultValidation(percentage);
            return _percentageRepository.Create(percentage);
        }

        public Percentage Update(Percentage percentage)
        {
            _percentageValidator.DefaultValidation(percentage);
            return _percentageRepository.Update(percentage);
        }

        public Percentage Delete(int id)
        {
            _percentageValidator.ValidateId(id);
            return _percentageRepository.Delete(id);
        }
    }
}