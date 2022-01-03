using System.Collections.Generic;

namespace IIAuctionHouse.DataAccess.Entities
{
    public class ForestryEnterpriseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ForestEntity> ForestEntities { get; set; }
    }
}