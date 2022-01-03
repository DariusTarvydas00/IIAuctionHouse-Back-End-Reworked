using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace IIAuctionHouse.DataAccess.Entities
{
    public class TreeTypeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Percentage { get; set; }

        public int? PercentageEntityId { get; set; }
        public PercentageEntity PercentageEntity { get; set; }
        public ICollection<PlotTreeTypeEntity> PlotEntitiesInE { get; set; }
    }
}