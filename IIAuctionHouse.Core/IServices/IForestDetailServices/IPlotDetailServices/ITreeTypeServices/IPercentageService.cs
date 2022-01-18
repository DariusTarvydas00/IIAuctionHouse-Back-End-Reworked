﻿using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;

namespace IIAuctionHouse.Core.IServices.IForestDetailServices.IPlotDetailServices.ITreeTypeServices
{
    public interface IPercentageService
    {
        List<Percentage> GetAll();
        Percentage NewPercentage(int percentage);
        Percentage Create(Percentage percentage);
        Percentage Update(Percentage percentage);
        Percentage UpdatePercentage(int id, int percentage);
        Percentage Delete(int id);
    }
}