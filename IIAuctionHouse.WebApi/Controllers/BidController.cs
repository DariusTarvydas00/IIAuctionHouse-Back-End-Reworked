using System;
using System.IO;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.WebApi.Dto.BidDto;
using IIAuctionHouse.WebApi.Exceptions;
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
                _bidService = bidService ?? throw new InvalidDataException(BidControllerExceptions.ServiceIsNull);
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
                if (id < 1)
                    return BadRequest(GeneralExceptions.IdNullOrLess);
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
            public ActionResult Post([FromBody] BidPostDto userPostDto)
            {
                if (userPostDto == null)
                    return BadRequest(BidControllerExceptions.MissingSomeInformation);
                try
                {
                    var newBid = _bidService.NewBid(userPostDto.Value, userPostDto.User, userPostDto.Forest);
                    return Ok(_bidService.Create(newBid));
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }

            [HttpPut]
            public ActionResult Put(int id, [FromBody] Bid bid)
            {
                if (bid == null)
                    return BadRequest(BidControllerExceptions.MissingSomeInformation);
                if (id != bid.Id || id < 1)
                    return BadRequest(GeneralExceptions.NotMatchingId);
                try
                {
                    var newBid = _bidService.UpdateBid(id, bid.BidAmount, bid.User, bid.Forest);
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
                if (id < 1)
                    return BadRequest(GeneralExceptions.IdNullOrLess);
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