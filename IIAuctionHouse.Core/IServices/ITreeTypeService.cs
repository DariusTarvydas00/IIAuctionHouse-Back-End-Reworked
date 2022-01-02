﻿using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.IServices
{
    public interface ITreeTypeService
    {
        List<TreeType> GetAll();
        
        TreeType GetById(int id);

        TreeType NewTreeType(string name, Percentage percentage);

        TreeType Create(TreeType treeType);
        
        TreeType Update(TreeType treeType);

        TreeType Delete(int id);
    }
}