using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Domain.IRepositories
{
    public interface IUserRepository
    {
        IEnumerable<User> FindAll();
        User GetById(int id);
        User Create(User user);
        User Update(User user);
        User Delete(int id);
    }
}