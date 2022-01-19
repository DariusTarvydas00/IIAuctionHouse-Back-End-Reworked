using System;
using System.Linq;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;
using IIAuctionHouse.DataAccess.Exceptions;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestUidRepositories;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestUidRepositories.IEachUidRepositories;

namespace IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories.ForestUidRepositories
{
    public class ForestUidRepository: IForestUidRepository
    {
        private readonly MainDbContext _ctx;
        private readonly IForestFirstUidRepository _forestFirstUidRepository;
        private readonly IForestSecondUidRepository _forestSecondUidRepository;
        private readonly IForestThirdUidRepository _forestThirdUidRepository;

        public ForestUidRepository(MainDbContext ctx, 
            IForestFirstUidRepository forestFirstUidRepository,
            IForestSecondUidRepository forestSecondUidRepository,
            IForestThirdUidRepository forestThirdUidRepository)
        {
            _ctx = ctx ?? throw new NullReferenceException(DataAccessExceptions.NullContext);
            _forestFirstUidRepository = forestFirstUidRepository;
            _forestSecondUidRepository = forestSecondUidRepository;
            _forestThirdUidRepository = forestThirdUidRepository;
        }
        
        public ForestUid GetForestUid(int id)
        {
           var forestUid = _ctx.ForestUidDbSet.FirstOrDefault(sql => sql.Id == id);
           return new ForestUid()
           {
               Id = forestUid.Id,
               FirstUid = GetForestUidFirst(forestUid.ForestUidFirstSql.Id),
               SecondUid = GetForestUidSecond(forestUid.ForestUidSecondSql.Id),
               ThirdUid = GetForestUidThird(forestUid.ForestUidThirdSql.Id)
           };
        }

        public ForestUidFirst GetForestUidFirst(int id)
        {
            return _forestFirstUidRepository.GetById(id);
        }

        public ForestUidSecond GetForestUidSecond(int id)
        {
            return _forestSecondUidRepository.GetById(id);
        }

        public ForestUidThird GetForestUidThird(int id)
        {
            return _forestThirdUidRepository.GetById(id);
        }
    }
}