using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.Domain.Services
{
    public class AuctionService: IAuctionService
    {
        private readonly IAuctionRepository _auctionRepository;

        public AuctionService(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository ?? throw new  NullReferenceException("Forestry Enterprise Repository Can Not Be Null");
        }

        public List<Forest> GetAll()
        {
            return _auctionRepository.FindAll().ToList();
        }
    }
}