using System;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.WebApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class BidController : Controller
        {
            private readonly IBidService _bidService;

            public BidController(IBidService bidService)
            {
                _bidService = bidService ?? throw new NullReferenceException("Bid Service Can Not Be Null");
            }

            [HttpGet]
            public ActionResult GetAll()
            {
                try
                {
                    return Ok(_bidService.GetAll());
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }

            [HttpGet("{id}")]
            public ActionResult GetById(int id)
            {
                try
                {
                    return Ok(_bidService.GetById(id));
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }

            [HttpPost]
            public ActionResult Post([FromBody] BidDto bid)
            {
                try
                {
                    var newBid = _bidService.NewBid(bid.Id, bid.BidAmount, bid.ForestId, bid.UserId);
                    return Ok(_bidService.Create(newBid));
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }

            [HttpPut]
            public ActionResult Put([FromBody] BidDto bid)
            {
                try
                {
                    var newBid = _bidService.NewBid(bid.Id, bid.BidAmount, bid.ForestId, bid.UserId);
                    return Ok(_bidService.Update(newBid));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            [HttpDelete]
            public ActionResult Delete(int id)
            {
                try
                {
                    return Ok(_bidService.Delete(id));
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
        }
}