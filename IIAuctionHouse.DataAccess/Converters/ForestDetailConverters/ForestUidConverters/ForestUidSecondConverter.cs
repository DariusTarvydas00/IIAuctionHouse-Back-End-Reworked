using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestUidEntities;

namespace IIAuctionHouse.DataAccess.Converters.ForestDetailConverters.ForestUidConverters
{
    public class ForestUidSecondConverter
    {
        public ForestUidSecond Convert(ForestUidSecondSql forestUidSecondSql)
        {
            return new ForestUidSecond()
            {
                Id = forestUidSecondSql.Id,
                Value = forestUidSecondSql.Value
            };
        }

        public ForestUidSecondSql Convert(ForestUidSecond forestUidSecond)
        {
            return new ForestUidSecondSql()
            {
                Id = forestUidSecond.Id,
                Value = forestUidSecond.Value
            };
        }
    }
}