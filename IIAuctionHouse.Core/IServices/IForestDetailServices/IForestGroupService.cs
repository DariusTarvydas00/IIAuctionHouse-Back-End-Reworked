using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels;

namespace IIAuctionHouse.Core.IServices.IForestDetailServices
{
    public interface IForestGroupService
    {
        List<ForestGroup> GetAll();
        ForestGroup GetById(int id);
        ForestGroup NewForestGroup(int id);
        ForestGroup NewForestGroup(string name);
        ForestGroup Create(ForestGroup tree);
        ForestGroup Update(ForestGroup tree);
        ForestGroup Delete(int id);
        ForestGroup UpdateForestGroup(int id, string name);
    }
}