using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IEachUidServices;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IEachUidServices.EachUid;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;

namespace IIAuctionHouse.Domain.Services.ForestDetailServices.ForestUidServices
{
    public class ForestUidService: IForestUidService
    {
        private readonly IForestFirstUidService _forestFirstUidService;
        private readonly IForestSecondUidService _forestSecondUidService;
        private readonly IForestThirdUidService _forestThirdUidService;

        public ForestUidService(IForestFirstUidService forestFirstUidService, IForestSecondUidService forestSecondUidService, IForestThirdUidService forestThirdUidService)
        {
            _forestFirstUidService = forestFirstUidService ?? throw new NullReferenceException("Forest First Unique Service Can Not Be Null");
            _forestSecondUidService = forestSecondUidService ?? throw new NullReferenceException("Forest Second Unique Service Can Not Be Null");
            _forestThirdUidService = forestThirdUidService ?? throw new NullReferenceException("Forest Third Unique Service Can Not Be Null");
        }

        public ForestUid GetForestUid(int firstUid, int secondUid, int thirdUid)
        {
            var first = _forestFirstUidService.GetById(firstUid);
            var second = _forestSecondUidService.GetById(secondUid);
            var third = _forestThirdUidService.GetById(thirdUid);
            if (first != null || second != null || third !=null)
            {
                return new ForestUid()
                {
                    FirstUid = first,
                    SecondUid = second,
                    ThirdUid = third
                };
                
            }
            return null;

        }

        public List<ForestUidFirst> GetAllFirstUids()
        {
            return _forestFirstUidService.GetAll().ToList();
        }

        public List<ForestUidSecond> GetAllSecondUids()
        {
            return _forestSecondUidService.GetAll().ToList();
        }

        public List<ForestUidThird> GetAllThirdUids()
        {
            return _forestThirdUidService.GetAll().ToList();
        }
    }
}