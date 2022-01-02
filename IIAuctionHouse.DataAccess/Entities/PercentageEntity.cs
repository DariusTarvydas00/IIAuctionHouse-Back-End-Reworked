using System.Collections.Generic;

namespace IIAuctionHouse.DataAccess.Entities
{
    public class PercentageEntity
    {
        public int Id { get; set; }
        public int PercentageEntityValue { get; set; }

        public ICollection<TreeTypeEntity> TreeTypeEntities { get; set; }
    }
}