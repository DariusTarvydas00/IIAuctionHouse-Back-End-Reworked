using System.Collections.Generic;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;
using IIAuctionHouse.Core.Models.UserDetailModels;

namespace IIAuctionHouse.Core.IServices
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int id);
        User Create(User user);
        User Update(User user);
        User Delete(int id);
        User NewUser(int userDtoId, string userDtoFirstName, string userDtoLastName, UserDetails userDtoUserDetails, List<ForestUid> forestUid);
    }
}