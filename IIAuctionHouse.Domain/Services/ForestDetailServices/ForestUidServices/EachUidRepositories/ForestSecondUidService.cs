using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IForestUidServices;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IForestUidServices.IEachUidServices;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestUidRepositories.IEachUidRepositories;
using IIAuctionHouse.Domain.ServiceExceptions;

namespace IIAuctionHouse.Domain.Services.ForestDetailServices.ForestUidServices.EachUidRepositories
{
    public class ForestSecondUidService: IForestSecondUidService
    {
        private readonly IForestSecondUidRepository _forestSecondUidRepository;

        public ForestSecondUidService(IForestSecondUidRepository forestSecondUidRepository)
        {
            _forestSecondUidRepository = forestSecondUidRepository ?? throw new NullReferenceException(ServicesExceptions.NullRepository);
        }
        
        public List<ForestUidSecond> GetAll()
        {
            return _forestSecondUidRepository.FindAll().ToList();
        }
        
        public ForestUidSecond NewSecondUid(int value)
        {
            if (value < 1)
                throw new InvalidDataException(ServicesExceptions.InvalidId);
            return new ForestUidSecond()
            {
                Value = value
            };
        }

        public ForestUidSecond Create(ForestUidSecond forestUidSecond)
        {
            if (forestUidSecond == null)
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            return _forestSecondUidRepository.Create(forestUidSecond);
            throw new System.NotImplementedException();
        }

        public ForestUidSecond Update(ForestUidSecond forestUidSecond)
        {
            if (forestUidSecond == null)
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            return _forestSecondUidRepository.Update(forestUidSecond);
        }

        public ForestUidSecond Delete(int id)
        {
            if (id < 1)
                throw new InvalidDataException(ServicesExceptions.InvalidId);
            return _forestSecondUidRepository.Delete(id);
        }

        public ForestUidSecond UpdateSecondUid(int id, int value)
        {
            if (id < 1 || value < 1 )
                throw new InvalidDataException(ServicesExceptions.InvalidId +" or "+ ServicesExceptions.InvalidValue);
            return new ForestUidSecond() {Id = id,Value = value};
        }
    }
}