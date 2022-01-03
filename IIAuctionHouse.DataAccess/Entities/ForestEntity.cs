using System.Collections.Generic;

namespace IIAuctionHouse.DataAccess.Entities
{
    public class ForestEntity
    {
        public int Id { get; set; }
        public string ForestGroup { get; set; }
        
        public int ForestryEnterpriseId { get; set; }

        public ForestryEnterpriseEntity ForestryEnterpriseEntity { get; set; }

        //public int ForestLocationEntityId { get; set; }
        //public ForestLocationEntity ForestLocationEntity { get; set; }
         
        public List<PlotEntity> PlotEntities { get; set; }
      //   
      // //  public int ForestUidId { get; set; }
         public ForestUidEntity ForestUidpropEntity { get; set; }
      //   
          public List<BidEntity> BidEntities { get; set; }

    }
}