using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestUidEntities;

namespace IIAuctionHouse.DataAccess.Converters.ForestDetailConverters.ForestUidConverters
{
    public class ForestUidConverter
    {
        public ForestUid Convert(ForestUidSql forestUidSql)
        {
            return new ForestUid()
            {
                Id = forestUidSql.Id,
                FirstUid = new ForestUidFirst()
                {
                    Id = forestUidSql.ForestUidFirstSql.Id,
                    Value = forestUidSql.ForestUidFirstSql.Value
                },
                SecondUid = new ForestUidSecond()
                {
                    Id = forestUidSql.ForestUidSecondSql.Id,
                    Value = forestUidSql.ForestUidSecondSql.Value
                },
                ThirdUid = new ForestUidThird()
                {
                    Id = forestUidSql.ForestUidSecondSql.Id,
                    Value = forestUidSql.ForestUidSecondSql.Value
                },
            };
        }

        public ForestUidSql Convert(ForestUid forestUid)
        {
            return new ForestUidSql()
            {
                Id = forestUid.Id,
                ForestUidFirstSqlId = forestUid.FirstUid.Id,
                ForestUidSecondSqlId = forestUid.SecondUid.Id,
                ForestUidThirdSqlId = forestUid.ThirdUid.Id
            };
        }
    }
}