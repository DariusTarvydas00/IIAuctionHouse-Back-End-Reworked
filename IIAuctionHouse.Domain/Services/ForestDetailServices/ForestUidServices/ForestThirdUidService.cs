using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IForestUidServices;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestUidRepositories;
using IIAuctionHouse.Domain.ServiceExceptions;

namespace IIAuctionHouse.Domain.Services.ForestDetailServices.ForestUidServices
{
    public class ForestThirdUidService: IForestThirdUidService
    {
        private readonly IForestThirdUidRepository _forestThirdUidRepository;

        public ForestThirdUidService(IForestThirdUidRepository forestThirdUidRepository)
        {
            _forestThirdUidRepository = forestThirdUidRepository ?? throw new NullReferenceException(ServicesExceptions.NullRepository);
        }
        
        public List<ForestUidThird> GetAll()
        {
            return _forestThirdUidRepository.FindAll().ToList();
        }
        
        public ForestUidThird NewThirdUid(int value)
        {
            if (value < 1)
                throw new InvalidDataException(ServicesExceptions.InvalidId);
            return new ForestUidThird()
            {
                Value = value
            };
        }

        public ForestUidThird Create(ForestUidThird forestUidThird)
        {
            if (forestUidThird == null)
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            return _forestThirdUidRepository.Create(forestUidThird);
        }

        public ForestUidThird Update(ForestUidThird forestUidThird)
        {
            if (forestUidThird == null)
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            return _forestThirdUidRepository.Update(forestUidThird);
        }

        public ForestUidThird Delete(int id)
        {
            if (id < 1)
                throw new InvalidDataException(ServicesExceptions.InvalidId);
            return _forestThirdUidRepository.Delete(id);
        }

        public ForestUidThird UpdateThirdUid(int id, int value)
        {
            if (id < 1 || value < 1 )
                throw new InvalidDataException(ServicesExceptions.InvalidId +" or "+ ServicesExceptions.InvalidValue);
            return new ForestUidThird() {Id = id,Value = value};
        }
    }
}