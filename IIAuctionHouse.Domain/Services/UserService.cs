using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Core.Models.UserDetailModels;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.Domain.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new NullReferenceException("User Repository Cannot be null");
        }

        public List<User> GetAll()
        {
            return _userRepository.FindAll().ToList();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User NewUser(string firstName, string lastName, UserDetails userDetails)
        {
            if (firstName.Any(char.IsDigit) || string.IsNullOrEmpty(firstName) || lastName.Any(char.IsDigit) || string.IsNullOrEmpty(lastName) || userDetails == null)
                throw new InvalidDataException("User is missing some information");
            return new User()
            {
                FirstName = firstName,
                LastName = lastName,
                UserDetails = userDetails
            };
        }

        public User NewUserCheck(int id)
        {
            return new User()
            {
                Id = id
            };
        }

        public User Create(User user)
        {
            return _userRepository.Create(user);
        }

        public User Update(User user)
        {
            return _userRepository.Update(user);
        }

        public User Delete(int id)
        {
            return _userRepository.Delete(id);
        }

        public User UpdateUser(int id, string firstName, string lastName, UserDetails userDetails)
        {
            if (id < 1 || firstName.Any(char.IsDigit) || string.IsNullOrEmpty(firstName) || lastName.Any(char.IsDigit) || string.IsNullOrEmpty(lastName) || userDetails == null)
                throw new InvalidDataException("User is missing some information");
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