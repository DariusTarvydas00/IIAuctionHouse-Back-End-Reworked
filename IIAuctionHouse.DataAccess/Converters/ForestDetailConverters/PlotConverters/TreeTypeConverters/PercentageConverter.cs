using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.PlotEntities.TreeTypeEntities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IIAuctionHouse.DataAccess.Converters.ForestDetailConverters.PlotConverters.TreeTypeConverters
{
    public class PercentageConverter
    {
        public Percentage Convert(PercentageSql percentageSql)
        {
            return new Percentage()
            {
                Id = percentageSql.Id,
                Value = percentageSql.Value
            };
        }

        public PercentageSql Convert(Percentage percentage)
        {
            return new PercentageSql()
            {
                Id = percentage.Id,
                Value = percentage.Value
            };
        }
    }
    
    
}