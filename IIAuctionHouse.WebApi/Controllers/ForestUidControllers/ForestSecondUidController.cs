using System;
using IIAuctionHouse.Core.IServices.IForestUidServices;
using IIAuctionHouse.Core.Models.ForestUid;
using IIAuctionHouse.WebApi.Dtos.ForestUidDtos;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers.ForestUidControllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class ForestSecondUidController : ControllerBase
        {
            private readonly IForestSecondUidService _forestSecondUidService;

            public ForestSecondUidController(IForestSecondUidService forestSecondUidService)
            {
                _forestSecondUidService = forestSecondUidService;
            }

            [HttpGet]
            public ActionResult GetAll()
            {
                try
                {
                    return Ok(_forestSecondUidService.GetAll());
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
                
            }

            [HttpPost]
            public ActionResult Post([FromBody] ForestUidPostTemplateDto forestUidPostDto)
            {
                if (forestUidPostDto.Value is < 1 or > 9999)
                    return BadRequest("Forest Second Uid to Update is missing some information");
                try
                {
                    var newForestSecondUid = _forestSecondUidService.NewSecondUid(forestUidPostDto.Value);
                    return Ok(_forestSecondUidService.Create(newForestSecondUid));
                }
                catch(Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            
            [HttpPut("{id}")]
            public ActionResult Put(int id, [FromBody] ForestUidSecond forestUidSecond)
            {
                if (id != forestUidSecond.Id || id < 1)
                    return BadRequest("Id needs to match in both url and object");
                if (forestUidSecond.Value is < 1 or > 9999)
                    return BadRequest("Forest Second Uid to Update is missing some information");
                try
                {
                    var treeTypeUpdate = _forestSecondUidService.UpdateSecondUid(forestUidSecond.Id, forestUidSecond.Value);
                    return Ok(_forestSecondUidService.Update(treeTypeUpdate));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            [HttpDelete("{id}")]
            public ActionResult Delete(int id)
            {
                try
                {
                    return Ok(_forestSecondUidService.Delete(id));
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
        }
}