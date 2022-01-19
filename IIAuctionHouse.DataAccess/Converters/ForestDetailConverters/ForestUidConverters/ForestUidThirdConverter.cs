using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestUidEntities;

namespace IIAuctionHouse.DataAccess.Converters.ForestDetailConverters.ForestUidConverters
{
    public class ForestUidThirdConverter
    {
        public ForestUidThird Convert(ForestUidThirdSql forestUidThirdSql)
        {
            return new ForestUidThird()
            {
                Id = forestUidThirdSql.Id,
                Value = forestUidThirdSql.Value
            };
        }

        public ForestUidThirdSql Convert(ForestUidThird forestUidThird)
        {
            return new ForestUidThirdSql()
            {
                Id = forestUidThird.Id,
                Value = forestUidThird.Value
            };
        }
    }
}