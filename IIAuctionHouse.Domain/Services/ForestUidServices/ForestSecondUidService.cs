using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestUidServices;
using IIAuctionHouse.Core.Models.ForestUid;
using IIAuctionHouse.Domain.IRepositories.IForestUidRepositories;

namespace IIAuctionHouse.Domain.Services.ForestUidServices
{
    public class ForestSecondUidService: IForestSecondUidService
    {
        private readonly IForestSecondUidRepository _forestSecondUidRepository;

        public ForestSecondUidService(IForestSecondUidRepository forestSecondUidRepository)
        {
            _forestSecondUidRepository = forestSecondUidRepository ?? throw new NullReferenceException("Second Forest Uid Repository Cannot be null");;;
        }
        
        public List<ForestUidSecond> GetAll()
        {
            return _forestSecondUidRepository.FindAll().ToList();
        }
        
        public ForestUidSecond NewSecondUid(int value)
        {
            if (value < 1)
                throw new InvalidDataException("Second Forest Uid is missing some information");
            return new ForestUidSecond()
            {
                Value = value
            };
        }

        public ForestUidSecond Create(ForestUidSecond forestUidSecond)
        {
            if (forestUidSecond == null)
                throw new InvalidDataException("Second Forest Uid is missing some information");
            return _forestSecondUidRepository.Create(forestUidSecond);
            throw new System.NotImplementedException();
        }

        public ForestUidSecond Update(ForestUidSecond forestUidSecond)
        {
            if (forestUidSecond == null)
                throw new InvalidDataException("Second Forest Uid to update is missing some information");
            return _forestSecondUidRepository.Update(forestUidSecond);
        }

        public ForestUidSecond Delete(int id)
        {
            if (id < 1)
                throw new InvalidDataException("Incorrect Second Forest Uid Id");
            return _forestSecondUidRepository.Delete(id);
        }

        public ForestUidSecond UpdateSecondUid(int id, int value)
        {
            if (id < 1 || value < 1 )
                throw new InvalidDataException("Incorrect Second Forest Uid Id");
            return new ForestUidSecond() {Id = id,Value = value};
        }
    }
}