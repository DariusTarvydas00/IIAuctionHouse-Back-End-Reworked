using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IEachUidServices.EachUid;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestUidRepositories.IEachUidRepositories;

namespace IIAuctionHouse.Domain.Services.ForestDetailServices.ForestUidServices.UidServices
{
    public class ThirdUidService: IForestThirdUidService
    {
        private readonly IForestThirdUidRepository _forestThirdUidRepository;

        public ThirdUidService(IForestThirdUidRepository forestThirdUidRepository)
        {
            _forestThirdUidRepository = forestThirdUidRepository ?? throw new NullReferenceException("Forest Third Uid Repository Can Not Be Null");
        }

        public List<ForestUidThird> GetAll()
        {
            return _forestThirdUidRepository.FindAll().ToList();
        }

        public ForestUidThird GetById(int third)
        {
            if (third < 1)
                throw new Exception("Forest Third Unique Id Can Not Be Less Than 1");
            return _forestThirdUidRepository.GetById(third);
        }
    }
}