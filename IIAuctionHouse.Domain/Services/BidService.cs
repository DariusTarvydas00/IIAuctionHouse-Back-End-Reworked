﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Domain.IRepositories;
using IIAuctionHouse.Domain.ServiceExceptions;

namespace IIAuctionHouse.Domain.Services
{
    public class BidService: IBidService
    {
        private readonly IBidRepository _bidRepository;

        public BidService(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository ?? throw new NullReferenceException(ServicesExceptions.NullRepository);
        }

        public List<Bid> GetAll()
        {
            return _bidRepository.FindAll().ToList();
        }

        public Bid GetById(int id)
        {
            if (id < 1)
                throw new InvalidDataException(ServicesExceptions.InvalidId);
            return _bidRepository.GetById(id);
        }

        public Bid NewBid(int bidAmount, User user, Forest forest)
        {
            if (bidAmount < 1 || user == null || forest == null)
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            return new Bid()
            {
                BidAmount = bidAmount,
                User = user,
                Forest = forest,
            };
        }

        public Bid Create(Bid bid)
        {
            if (bid == null)
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            return _bidRepository.Create(bid);
        }

        public Bid Update(Bid bid)
        {
            if (bid == null)
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            return _bidRepository.Update(bid);
        }

        public Bid Delete(int id)
        {
            if (id < 1)
                throw new InvalidDataException(ServicesExceptions.InvalidId);
            return _bidRepository.Delete(id);
        }

        public Bid UpdateBid(int id, int bidAmount, User user, Forest forest)
        {
            if (id < 1 ||bidAmount < 1 || user == null || forest == null)
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            return new Bid()
            {
                BidAmount = bidAmount,
                User = user,
                Forest = forest,
            };
        }
        
    }
}