using System;
using IIAuctionHouse.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers
{
    public class AuctionController: ControllerBase
    {
        private readonly IAuctionService _auctionService;

        public AuctionController(IAuctionService auctionService)
        {
            _auctionService = auctionService ?? throw new NullReferenceException("Auction Service Can Not Be Null");
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(_auctionService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}