using System;
using IIAuctionHouse.Core.IServices.IForestUidServices;
using IIAuctionHouse.Core.Models.ForestUid;
using IIAuctionHouse.WebApi.Dtos.ForestUidDtos;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers.ForestUidControllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class ForestThirdUidController : ControllerBase
        {
            private readonly IForestThirdUidService _forestThirdUidService;

            public ForestThirdUidController(IForestThirdUidService forestThirdUidService)
            {
                _forestThirdUidService = forestThirdUidService;
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
            public ActionResult Post([FromBody] ForestUidPostTemplateDto forestUidPostDto)
            {
                if (forestUidPostDto.Value is < 1 or > 9999)
                    return BadRequest("Forest Third Uid to Update is missing some information");
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
                    return BadRequest("Id needs to match in both url and object");
                if (forestUidThird.Value is < 1 or > 9999)
                    return BadRequest("Forest Third Uid to Update is missing some information");
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