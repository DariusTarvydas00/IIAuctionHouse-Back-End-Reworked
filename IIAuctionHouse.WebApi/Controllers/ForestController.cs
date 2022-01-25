using System;
using System.IO;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.WebApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForestController : Controller
    {
        private readonly IForestService _forestService;

        public ForestController(IForestService forestService)
        {
            _forestService = forestService ?? throw new InvalidDataException("Forest Controller Can Not be Null");
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
        public ActionResult Post([FromBody] ForestDto forestDto)
        {
         
            try
            {
                var newForest = _forestService.NewForest(forestDto.ForestGroupSubGroup, forestDto.ForestLocation,forestDto.ForestUid, forestDto.ForestryEnterprise);
                return Ok(_forestService.Create(newForest));
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPut]
        public ActionResult Put(int id, [FromBody]ForestDto forestDto)
        {
            if (id != forestDto.Id)
                throw new Exception("Id Does Not Match");
            try
            {
                var newForest = _forestService.NewForest(forestDto.Id, forestDto.ForestGroupSubGroup, forestDto.ForestLocation,forestDto.ForestUid,  forestDto.ForestryEnterprise);
                return Ok(_forestService.Update(newForest));
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
                return BadRequest();
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