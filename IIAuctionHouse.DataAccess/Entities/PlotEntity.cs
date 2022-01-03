using System.Collections.Generic;
using IIAuctionHouse.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IIAuctionHouse.DataAccess.Entities
{
    public class PlotEntity
    {
        public int Id { get; set; }
        public double PlotSize { get; set; }
        public string PlotResolution { get; set; }
        public double PlotTenderness { get; set; }
        public int Volume { get; set; }
        public int AverageTreeHeight { get; set; }
         public virtual ICollection<PlotTreeTypeEntity> TreeTypesInE { get; set; }
        //
        // public int ForestEntityId { get; set; }
        // public ForestEntity ForestEntity { get; set; }
    }
}