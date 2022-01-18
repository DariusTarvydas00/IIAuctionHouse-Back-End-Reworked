using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.UserDetailModels;
using IIAuctionHouse.Domain.IRepositories;
using IIAuctionHouse.Domain.ServiceExceptions;

namespace IIAuctionHouse.Domain.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new NullReferenceException(ServicesExceptions.NullRepository);
        }

        public List<User> GetAll()
        {
            return _userRepository.FindAll().ToList();
        }

        public User GetById(int id)
        {
            if (id < 1)
                throw new InvalidDataException(ServicesExceptions.InvalidId);
            return _userRepository.GetById(id);
        }

        public User NewUser(string firstName, string lastName, UserDetails userDetails)
        {
            if (firstName.Any(char.IsDigit) || string.IsNullOrEmpty(firstName) || lastName.Any(char.IsDigit) || string.IsNullOrEmpty(lastName) || userDetails == null)
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            return new User()
            {
                FirstName = firstName,
                LastName = lastName,
                UserDetails = userDetails
            };
        }

        public User NewUserCheck(int id)
        {
            if (id < 1)
                throw new InvalidDataException(ServicesExceptions.InvalidId);
            return new User()
            {
                Id = id
            };
        }

        public User Create(User user)
        {
            if (user ==null)
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            return _userRepository.Create(user);
        }

        public User Update(User user)
        {
            if (user ==null)
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            return _userRepository.Update(user);
        }

        public User Delete(int id)
        {
            if (id < 1)
                throw new InvalidDataException(ServicesExceptions.InvalidId);
            return _userRepository.Delete(id);
        }

        public User UpdateUser(int id, string firstName, string lastName, UserDetails userDetails)
        {
            if (id < 1 || firstName.Any(char.IsDigit) || string.IsNullOrEmpty(firstName) || lastName.Any(char.IsDigit) || string.IsNullOrEmpty(lastName) || userDetails == null)
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
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