using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestUidServices;
using IIAuctionHouse.Core.Models.ForestUid;
using IIAuctionHouse.Domain.IRepositories.IForestUidRepositories;

namespace IIAuctionHouse.Domain.Services.ForestUidServices
{
    public class ForestFirstUidService: IForestFirstUidService
    {
        
        private readonly IForestFirstUidRepository _forestFirstUidRepository;

        public ForestFirstUidService(IForestFirstUidRepository forestFirstUidRepository)
        {
            _forestFirstUidRepository = forestFirstUidRepository ?? throw new NullReferenceException("First Forest Uid Repository Cannot be null");;;
        }
        
        public List<ForestUidFirst> GetAll()
        {
            return _forestFirstUidRepository.FindAll().ToList();
        }
        
        public ForestUidFirst NewFirstUid(int value)
        {
            if (value < 1)
                throw new InvalidDataException("First Forest Uid is missing some information");
            return new ForestUidFirst()
            {
                Value = value
            };
        }

        public ForestUidFirst Create(ForestUidFirst forestUidFirst)
        {
            if (forestUidFirst == null)
                throw new InvalidDataException("First Forest Uid is missing some information");
            return _forestFirstUidRepository.Create(forestUidFirst);
            throw new System.NotImplementedException();
        }

        public ForestUidFirst Update(ForestUidFirst forestUidFirst)
        {
            if (forestUidFirst == null)
                throw new InvalidDataException("First Forest Uid to update is missing some information");
            return _forestFirstUidRepository.Update(forestUidFirst);
        }

        public ForestUidFirst Delete(int id)
        {
            if (id < 1)
                throw new InvalidDataException("Incorrect First Forest Uid Id");
            return _forestFirstUidRepository.Delete(id);
        }

        public ForestUidFirst UpdateFirstUid(int id, int value)
        {
            if (id < 1 || value < 1 )
                throw new InvalidDataException("Incorrect First Forest Uid Id");
            return new ForestUidFirst() {Id = id,Value = value};
        }
    }
}