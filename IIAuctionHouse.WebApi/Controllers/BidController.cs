using System;
using System.IO;
using IIAuctionHouse.Core.IServices;
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
            private readonly IUserService _userService;
            private readonly IForestService _forestService;

            public BidController(IBidService bidService, IUserService userService, IForestService forestService)
            {
                _bidService = bidService ?? throw new InvalidDataException(ControllersExceptions.NullService);
                _userService = userService ?? throw new InvalidDataException(ControllersExceptions.NullService);
                _forestService = forestService ?? throw new InvalidDataException(ControllersExceptions.NullService);
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
                    return BadRequest(ControllersExceptions.IdNullOrLess);
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
            public ActionResult Post([FromBody] BidPostDto bidPostDto)
            {
                if (bidPostDto == null)
                    return BadRequest(ControllersExceptions.MissingSomeInformation);
                try
                {
                    var newUser = _userService.NewUser(bidPostDto.UserPostIdDto.Id);
                    var newForest = _forestService.NewForestCheck(bidPostDto.ForestPostIdDto.ForestUid.ForestFirstUidDto.Id);
                    var newBid = _bidService.NewBid(bidPostDto.Value, newUser, newForest);
                    return Ok(_bidService.Create(newBid));
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }

            [HttpPut]
            public ActionResult Put(int id, [FromBody] BidPutDto bidPutDto)
            {
                if (bidPutDto == null)
                    return BadRequest(ControllersExceptions.MissingSomeInformation);
                if (id != bidPutDto.Id || id < 1)
                    return BadRequest(ControllersExceptions.NotMatchingId);
                try
                {
                    var newUser = _userService.NewUser(bidPutDto.UserPostIdDto.Id);
                    var newForest = _forestService.NewForestCheck(bidPutDto.ForestPostIdDto.Id);
                    var newBid = _bidService.UpdateBid(id, bidPutDto.Value, newUser, newForest);
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
                    return BadRequest(ControllersExceptions.IdNullOrLess);
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