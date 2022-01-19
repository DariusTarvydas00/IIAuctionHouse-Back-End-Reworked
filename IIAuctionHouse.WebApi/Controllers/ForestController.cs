using System;
using System.IO;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.IServices.IForestDetailServices;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IForestUidServices;
using IIAuctionHouse.WebApi.Dto.ForestDto;
using IIAuctionHouse.WebApi.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForestController : Controller
    {
        private readonly IForestService _forestService;
        private readonly IForestUidService _forestUidService;
        private readonly IForestLocationService _forestLocationService;
        private readonly IForestEnterpriseService _forestEnterpriseService;
        private readonly IUserService _userService;
        private readonly IForestGroupService _forestGroupService;

        public ForestController(IForestService forestService, IForestUidService forestUidService, IForestLocationService forestLocationService,
            IForestEnterpriseService forestEnterpriseService, IUserService userService, IForestGroupService forestGroupService)
        {
            _forestService = forestService ?? throw new InvalidDataException(ControllersExceptions.NullService);
            _forestUidService = forestUidService ?? throw new InvalidDataException(ControllersExceptions.NullService);
            _forestLocationService = forestLocationService ?? throw new InvalidDataException(ControllersExceptions.NullService);
            _forestEnterpriseService = forestEnterpriseService ?? throw new InvalidDataException(ControllersExceptions.NullService);
            _userService = userService ?? throw new InvalidDataException(ControllersExceptions.NullService);
            _forestGroupService = forestGroupService ?? throw new InvalidDataException(ControllersExceptions.NullService);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(_forestService.GetAll());
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
                return Ok(_forestService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] ForestPostDto forestPostDto)
        {
            if (forestPostDto == null)
                return BadRequest(ControllersExceptions.MissingSomeInformation);
            try
            {
                var newUser = _userService.NewUser(forestPostDto.User.Id);
                var newForestryEnterprise = _forestEnterpriseService.NewForestryEnterprise(forestPostDto.ForestryEnterprise.Id);
                var newForestLocation = _forestLocationService.NewForestLocation(
                    forestPostDto.ForestLocation.GeoLocationX, forestPostDto.ForestLocation.GeoLocationY);
                var newForestUid = _forestUidService.NewForestUid(forestPostDto.ForestUid.ForestFirstUidDto.Id,
                    forestPostDto.ForestUid.ForestSecondUidDto.Id,
                    forestPostDto.ForestUid.ForestThirdUidDto.Id);
                var newForestGroup = _forestGroupService.NewForestGroup(forestPostDto.ForestGroup.Id);
                var newForest = _forestService.NewForest(newForestUid,newForestGroup,newForestLocation, newForestryEnterprise, newUser);
                return Ok(_forestService.Create(newForest));
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPut]
        public ActionResult Put(int id, [FromBody]ForestPutDto forestPutDto)
        {
            if (forestPutDto == null)
                return BadRequest(ControllersExceptions.MissingSomeInformation);
            if (id != forestPutDto.Id || id < 1)
                return BadRequest(ControllersExceptions.NotMatchingId);
            try
            {
                var newUser = _userService.NewUser(forestPutDto.UserIdDto.Id);
                var newForestryEnterprise = _forestEnterpriseService.GetById(forestPutDto.ForestryEnterpriseIdDto.Id);
                var forestUpdate = _forestService.UpdateForest(forestPutDto.Id, forestPutDto.ForestUid, forestPutDto.ForestGroup, forestPutDto.ForestLocation, newForestryEnterprise, newUser);
                return Ok(_forestService.Update(forestUpdate));
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
                return Ok(_forestService.Delete(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}