using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IEachUidServices.EachUid;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestUidRepositories.IEachUidRepositories;

namespace IIAuctionHouse.Domain.Services.ForestDetailServices.ForestUidServices.UidServices
{
    public class SecondUidService: IForestSecondUidService
    {
        private readonly IForestSecondUidRepository _forestSecondUidRepository;

        public SecondUidService(IForestSecondUidRepository forestSecondUidRepository)
        {
            _forestSecondUidRepository = forestSecondUidRepository ?? throw new NullReferenceException("Forest Second Uid Repository Can Not Be Null");
        }

        public List<ForestUidSecond> GetAll()
        {
            return _forestSecondUidRepository.FindAll().ToList();
        }

        public ForestUidSecond GetById(int subGroupId)
        {
            CheckId(subGroupId);
            return _forestSecondUidRepository.GetById(subGroupId);
        }
        
        private void CheckId(int id)
        {
            if (id < 1)
                throw new Exception("Forest Second Unique Id Can Not Be Less Than 1");
        }
    }
}