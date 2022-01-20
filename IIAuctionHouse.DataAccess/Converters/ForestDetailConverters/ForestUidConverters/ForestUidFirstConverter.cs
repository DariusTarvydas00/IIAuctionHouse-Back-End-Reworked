using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestUidEntities;

namespace IIAuctionHouse.DataAccess.Converters.ForestDetailConverters.ForestUidConverters
{
    public class ForestUidFirstConverter
    {
        public ForestUidFirst Convert(ForestUidFirstSql forestUidFirstSql)
        {
            return new ForestUidFirst()
            {
                Id = forestUidFirstSql.Id,
                Value = forestUidFirstSql.Value
            };
        }

        public ForestUidFirstSql Convert(ForestUidFirst forestUidFirst)
        {
            return new ForestUidFirstSql()
            {
                Id = forestUidFirst.Id,
                Value = forestUidFirst.Value
            };
        }
    }
}