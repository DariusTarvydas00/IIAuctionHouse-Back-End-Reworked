using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;
using IIAuctionHouse.Core.Models.UserDetailModels;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.Domain.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new NullReferenceException("");
        }

        public List<User> GetAll()
        {
            return _userRepository.FindAll().ToList();
        }

        public User GetById(int id)
        {
            if (id < 1)
                throw new InvalidDataException("");
            return _userRepository.GetById(id);
        }

        public User NewUser(string firstName, string lastName, UserDetails userDetails)
        {
            if (firstName.Any(char.IsDigit) || string.IsNullOrEmpty(firstName) || lastName.Any(char.IsDigit) || string.IsNullOrEmpty(lastName) || userDetails == null)
                throw new InvalidDataException("");
            return new User()
            {
                FirstName = firstName,
                LastName = lastName,
                UserDetails = userDetails
            };
        }

        public User NewUser(int id)
        {
            if (id < 1)
                throw new InvalidDataException("");
            return new User()
            {
                Id = id
            };
        }

        public User Create(User user)
        {
            if (user ==null)
                throw new InvalidDataException("");
            return _userRepository.Create(user);
        }

        public User Update(User user)
        {
            if (user ==null)
                throw new InvalidDataException("");
            return _userRepository.Update(user);
        }

        public User Delete(int id)
        {
            if (id < 1)
                throw new InvalidDataException("");
            return _userRepository.Delete(id);
        }

        public User NewUser(int userDtoId, string userDtoFirstName, string userDtoLastName, UserDetails userDtoUserDetails,
            List<ForestUid> forestUid)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(int id, string firstName, string lastName, UserDetails userDetails)
        {
            if (id < 1 || firstName.Any(char.IsDigit) || string.IsNullOrEmpty(firstName) || lastName.Any(char.IsDigit) || string.IsNullOrEmpty(lastName) || userDetails == null)
                throw new InvalidDataException("");
            return new User()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                UserDetails = userDetails
            };
        }
        
    }
}