using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.PlotEntities.TreeTypeEntities;

namespace IIAuctionHouse.DataAccess.Converters.ForestDetailConverters.PlotConverters.TreeTypeConverters
{
    public class PercentageConverter
    {
        public Percentage Convert(PercentageSql percentageSql)
        {
            return new Percentage()
            {
                Id = percentageSql?.Id ?? 0,
                Value = percentageSql?.Value ?? 0,
            };
        }

        public PercentageSql Convert(Percentage percentage)
        {
            return new PercentageSql()
            {
                Id = percentage?.Id ?? 0,
                Value = percentage?.Value ?? 0,
            };
        }
    }
    
    
}