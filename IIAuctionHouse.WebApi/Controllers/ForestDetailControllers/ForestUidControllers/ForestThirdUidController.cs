using System;
using System.IO;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IForestUidServices;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;
using IIAuctionHouse.WebApi.Dto.ForestDetailDto.ForestUidDto;
using IIAuctionHouse.WebApi.Exceptions;
using IIAuctionHouse.WebApi.Exceptions.ForestDetailsControllersExceptions.ForestUidControllersExceptions;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers.ForestDetailControllers.ForestUidControllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class ForestThirdUidController : ControllerBase
        {
            private readonly IForestThirdUidService _forestThirdUidService;

            public ForestThirdUidController(IForestThirdUidService forestThirdUidService)
            {
                _forestThirdUidService = forestThirdUidService ?? throw new InvalidDataException(ForestUidControllerException.ServiceIsNull);
            }

            [HttpGet]
            public ActionResult GetAll()
            {
                try
                {
                    return Ok(_forestThirdUidService.GetAll());
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
                
            }

            [HttpPost]
            public ActionResult Post([FromBody] ForestUidPostFstDto forestUidPostDto)
            {
                if (forestUidPostDto.Value is < 1 or > 9999)
                    return BadRequest(ForestUidControllerException.ValueNotInRange);
                try
                {
                    var newForestThirdUid = _forestThirdUidService.NewThirdUid(forestUidPostDto.Value);
                    return Ok(_forestThirdUidService.Create(newForestThirdUid));
                }
                catch(Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            
            [HttpPut("{id}")]
            public ActionResult Put(int id, [FromBody] ForestUidThird forestUidThird)
            {
                if (id != forestUidThird.Id || id < 1)
                    return BadRequest(GeneralExceptions.NotMatchingId);
                if (forestUidThird.Value is < 1 or > 9999)
                    return BadRequest(ForestUidControllerException.ValueNotInRange);
                try
                {
                    var treeTypeUpdate = _forestThirdUidService.UpdateThirdUid(forestUidThird.Id, forestUidThird.Value);
                    return Ok(_forestThirdUidService.Update(treeTypeUpdate));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            [HttpDelete("{id}")]
            public ActionResult Delete(int id)
            {
                if (id < 1)
                    return BadRequest(GeneralExceptions.IdNullOrLess);
                try
                {
                    return Ok(_forestThirdUidService.Delete(id));
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
        }
    }