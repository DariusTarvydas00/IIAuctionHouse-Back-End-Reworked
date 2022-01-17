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
        public class ForestFirstUidController : ControllerBase
        {
            private readonly IForestFirstUidService _forestFirstUidService;

            public ForestFirstUidController(IForestFirstUidService forestFirstUidService)
            {
                _forestFirstUidService = forestFirstUidService ?? throw new InvalidDataException(ForestUidControllerException.ServiceIsNull);
            }

            [HttpGet]
            public ActionResult GetAll()
            {
                try
                {
                    return Ok(_forestFirstUidService.GetAll());
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
                    var newForestFirstUid = _forestFirstUidService.NewFirstUid(forestUidPostDto.Value);
                    return Ok(_forestFirstUidService.Create(newForestFirstUid));
                }
                catch(Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            
            [HttpPut("{id}")]
            public ActionResult Put(int id, [FromBody] ForestUidFirst forestUidFirst)
            {
                if (id != forestUidFirst.Id || id < 1)
                    return BadRequest(GeneralExceptions.NotMatchingId);
                if (forestUidFirst.Value is < 1 or > 9999)
                    return BadRequest(ForestUidControllerException.ValueNotInRange);
                try
                {
                    var treeTypeUpdate = _forestFirstUidService.UpdateFirstUid(forestUidFirst.Id, forestUidFirst.Value);
                    return Ok(_forestFirstUidService.Update(treeTypeUpdate));
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
                    return Ok(_forestFirstUidService.Delete(id));
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
        }
}