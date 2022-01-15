using System;
using System.Linq;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.WebApi.Dtos.ForestGroupDto;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class ForestGroupController : ControllerBase
        {
            private readonly IForestGroupService _forestGroupService;

            public ForestGroupController(IForestGroupService forestGroupService)
            {
                _forestGroupService = forestGroupService;
            }

            [HttpGet]
            public ActionResult GetAll()
            {
                try
                {
                    return Ok(_forestGroupService.GetAll());
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
                
            }

            [HttpPost]
            public ActionResult Post([FromBody] ForestGroupPostDto forestGroup)
            {
                if (string.IsNullOrEmpty(forestGroup.Name))
                    return BadRequest("Forest Group to Post is missing some information");
                try
                {
                    var newForestGroup = _forestGroupService.NewForestGroup(forestGroup.Name);
                    return Ok(_forestGroupService.Create(newForestGroup));
                }
                catch(Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            
            [HttpPut("{id}")]
            public ActionResult Put(int id, [FromBody] ForestGroupPutDto treePutDto)
            {
                if (id != treePutDto.Id || id < 1)
                    return BadRequest("Id needs to match in both url and object");
                if (string.IsNullOrEmpty(treePutDto.Name) || treePutDto.Name.Any(char.IsDigit))
                    return BadRequest("Tree to Update is missing some information");
                Console.WriteLine(id+" "+ treePutDto.Id + " " + treePutDto.Name);
                try
                {
                    var treeTypeUpdate = _forestGroupService.UpdateForestGroup(treePutDto.Id, treePutDto.Name);
                    return Ok(_forestGroupService.Update(treeTypeUpdate));
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
                    return Ok(_forestGroupService.Delete(id));
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
        }
    }