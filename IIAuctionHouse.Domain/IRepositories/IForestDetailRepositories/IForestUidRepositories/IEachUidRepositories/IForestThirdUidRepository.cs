﻿using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;

namespace IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestUidRepositories.IEachUidRepositories
{
    public interface IForestThirdUidRepository
    {
        IEnumerable<ForestUidThird> FindAll();

        ForestUidThird GetById(int id);
    }
}