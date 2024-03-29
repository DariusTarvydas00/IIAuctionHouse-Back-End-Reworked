﻿using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestDetailServices.ITreeTypeServices.TTServices;
using IIAuctionHouse.Core.Models.ForestDetailModels.TreeTypes.TTModels;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.ITreeTypeRepositories.TTRepositories;

namespace IIAuctionHouse.Domain.Services.ForestDetailServices.TreeTypeServices.TTServices
{
    public class PercentageService: IPercentageService
    {
        private readonly IPercentageRepository _percentageRepository;

        public PercentageService(IPercentageRepository percentageRepository)
        {
            _percentageRepository = percentageRepository ?? throw new NullReferenceException("Percentage Service Can Not Be Null");
        }

        public List<Percentage> GetAll()
        {
            return _percentageRepository.FindAll().ToList();
        }

        public Percentage GetById(int percentageId)
        {
            if (percentageId < 1)
                throw new Exception("Percentage Id Can Not Be Less Than 1");
            return _percentageRepository.GetById(percentageId);
        }

    }
}