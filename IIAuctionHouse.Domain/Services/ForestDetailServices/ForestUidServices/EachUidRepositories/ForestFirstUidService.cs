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
    public class ForestFirstUidService: IForestFirstUidService
    {
        
        private readonly IForestFirstUidRepository _forestFirstUidRepository;

        public ForestFirstUidService(IForestFirstUidRepository forestFirstUidRepository)
        {
            _forestFirstUidRepository = forestFirstUidRepository ?? throw new NullReferenceException(ServicesExceptions.NullRepository);
        }
        
        public List<ForestUidFirst> GetAll()
        {
            return _forestFirstUidRepository.FindAll().ToList();
        }
        
        public ForestUidFirst NewFirstUid(int value)
        {
            if (value < 1)
                throw new InvalidDataException(ServicesExceptions.InvalidId);
            return new ForestUidFirst()
            {
                Value = value
            };
        }

        public ForestUidFirst Create(ForestUidFirst forestUidFirst)
        {
            if (forestUidFirst == null)
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            return _forestFirstUidRepository.Create(forestUidFirst);
            throw new System.NotImplementedException();
        }

        public ForestUidFirst Update(ForestUidFirst forestUidFirst)
        {
            if (forestUidFirst == null)
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            return _forestFirstUidRepository.Update(forestUidFirst);
        }

        public ForestUidFirst Delete(int id)
        {
            if (id < 1)
                throw new InvalidDataException(ServicesExceptions.InvalidId);
            return _forestFirstUidRepository.Delete(id);
        }

        public ForestUidFirst UpdateFirstUid(int id, int value)
        {
            if (id < 1 || value < 1 )
                throw new InvalidDataException(ServicesExceptions.InvalidId +" or "+ ServicesExceptions.InvalidValue);
            return new ForestUidFirst() {Id = id,Value = value};
        }
    }
}