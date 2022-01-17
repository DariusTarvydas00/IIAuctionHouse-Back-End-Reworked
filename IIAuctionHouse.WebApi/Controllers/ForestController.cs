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

        public ForestController(IForestService forestService, IForestUidService forestUidService, IForestLocationService forestLocationService,
            IForestEnterpriseService forestEnterpriseService, IUserService userService)
        {
            _forestService = forestService ?? throw new InvalidDataException(ForestControllerExceptions.ServiceIsNull);
            _forestUidService = forestUidService ?? throw new InvalidDataException(ForestControllerExceptions.ServiceIsNull);
            _forestLocationService = forestLocationService ?? throw new InvalidDataException(ForestControllerExceptions.ServiceIsNull);
            _forestEnterpriseService = forestEnterpriseService ?? throw new InvalidDataException(ForestControllerExceptions.ServiceIsNull);
            _userService = userService ?? throw new InvalidDataException(ForestControllerExceptions.ServiceIsNull);
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
                return BadRequest(GeneralExceptions.IdNullOrLess);
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
                return BadRequest(ForestControllerExceptions.MissingSomeInformation);
            try
            {
                var newUser = _userService.NewUserCheck(forestPostDto.UserIdDto.Id);
                var newForestryEnterprise = _forestEnterpriseService.GetById(forestPostDto.ForestryEnterprise.Id);
                var newForestLocation = _forestLocationService.NewForestLocation(
                    forestPostDto.ForestLocationPostDto.GeoLocationX, forestPostDto.ForestLocationPostDto.GeoLocationY);
                var newForestUid = _forestUidService.NewForestUid(forestPostDto.ForestUidIdDto.ForestFirstUidDto.Id,
                    forestPostDto.ForestUidIdDto.ForestSecondUidDto.Id,
                    forestPostDto.ForestUidIdDto.ForestThirdUidDto.Id);
                var newForest = _forestService.NewForest(newForestUid,forestPostDto.ForestGroup,newForestLocation, newForestryEnterprise, newUser);
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
                return BadRequest(ForestControllerExceptions.MissingSomeInformation);
            if (id != forestPutDto.Id || id < 1)
                return BadRequest(GeneralExceptions.NotMatchingId);
            try
            {
                var newUser = _userService.NewUserCheck(forestPutDto.UserIdDto.Id);
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
                return BadRequest(GeneralExceptions.IdNullOrLess);
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