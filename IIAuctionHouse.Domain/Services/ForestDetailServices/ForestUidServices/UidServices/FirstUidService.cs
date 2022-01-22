using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IEachUidServices.EachUid;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestUidRepositories.IEachUidRepositories;

namespace IIAuctionHouse.Domain.Services.ForestDetailServices.ForestUidServices.UidServices
{
    public class FirstUidService: IForestFirstUidService
    {
        private readonly IForestFirstUidRepository _forestFirstUidRepository;

        public FirstUidService(IForestFirstUidRepository forestFirstUidRepository)
        {
            _forestFirstUidRepository = forestFirstUidRepository ?? throw new NullReferenceException("Forest First Uid Repository Can Not Be Null");
        }

        public List<ForestUidFirst> GetAll()
        {
            return _forestFirstUidRepository.FindAll().ToList();
        }

        public ForestUidFirst GetById(int subGroupId)
        {
            CheckId(subGroupId);
            return _forestFirstUidRepository.GetById(subGroupId);
        }
        
        private void CheckId(int id)
        {
            if (id < 1)
                throw new Exception("Forest First Unique Id Can Not Be Less Than 1");
        }
    }
}