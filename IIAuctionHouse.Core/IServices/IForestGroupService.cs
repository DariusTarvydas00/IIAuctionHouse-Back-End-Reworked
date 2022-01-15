using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.IServices
{
    public interface IForestGroupService
    {
        List<ForestGroup> GetAll();
        ForestGroup NewForestGroup(string name);
        ForestGroup Create(ForestGroup tree);
        ForestGroup Update(ForestGroup tree);
        ForestGroup Delete(int id);
        ForestGroup UpdateForestGroup(int id, string name);
    }
}