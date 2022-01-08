using System.Collections.Generic;
using IIAuctionHouse.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IIAuctionHouse.DataAccess.Entities
{
    public class PlotSql
    {
        public int Id { get; set; }
        public double PlotSize { get; set; }
        public string PlotResolution { get; set; }
        public double PlotTenderness { get; set; }
        public int Volume { get; set; }
        public int AverageTreeHeight { get; set; }
        public int? TreeTypeSqlId { get; set; }
        public List<TreeTypeSql> TreeTypeSql { get; set; }
    }
}