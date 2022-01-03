﻿using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IIAuctionHouse.DataAccess.Entities
{
    public class PlotTreeTypeEntity
    {
        public int TreeTypeEntityId { get; set; }
        public TreeTypeEntity TreeTypeEntity { get; set; }
    
        public int? PlotEntityId { get; set; }
        public PlotEntity PlotEntity { get; set; }
    }
}