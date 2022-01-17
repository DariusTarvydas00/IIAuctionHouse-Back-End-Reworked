using System;
using IIAuctionHouse.Core.IServices.IForestUidServices;
using IIAuctionHouse.Core.Models.ForestUid;
using IIAuctionHouse.WebApi.Dtos.ForestUidDtos;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers.ForestUidControllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class ForestFirstUidController : ControllerBase
        {
            private readonly IForestFirstUidService _forestFirstUidService;

            public ForestFirstUidController(IForestFirstUidService forestFirstUidService)
            {
                _forestFirstUidService = forestFirstUidService;
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
            public ActionResult Post([FromBody] ForestUidPostTemplateDto forestUidPostDto)
            {
                if (forestUidPostDto.Value is < 1 or > 9999)
                    return BadRequest("Forest First Uid to Update is missing some information");
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
                    return BadRequest("Id needs to match in both url and object");
                if (forestUidFirst.Value is < 1 or > 9999)
                    return BadRequest("Forest First Uid to Update is missing some information");
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