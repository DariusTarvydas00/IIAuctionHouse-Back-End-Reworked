using System.Collections.Generic;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Core.Models.UserDetailModels;

namespace IIAuctionHouse.Core.IServices
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int id);
        User NewUser(string firstName, string lastName, UserDetails userDetails);
        User NewUserCheck(int id);
        User Create(User user);
        User Update(User user);
        User Delete(int id);
        User UpdateUser(int id, string firstName, string lastName, UserDetails userDetails);

    }
}