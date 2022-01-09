using System;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.WebApi.Dtos.ForestDto;
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
            _forestService = forestService;
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
                return BadRequest("Percentage Update is missing some information");
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
        public ActionResult Post([FromBody] ForestPostDto forest)
        {
            try
            {
                var newForest = _forestService.NewForest(forest.ForestUid, forest.ForestGroup, forest.ForestLocation, forest.Plots, forest.Bids, forest.ForestryEnterprise);
                return Ok(_forestService.Create(newForest));
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPut]
        public ActionResult Put(int id, [FromBody]ForestPutDto forest)
        {
            if (id != forest.Id)
                return BadRequest("Id needs to match in both url and object");
            try
            {
                var forestUpdate = _forestService.UpdateForest(forest.Id, forest.ForestUid, forest.ForestGroup, forest.ForestLocation, forest.Plots, forest.Bids, forest.ForestryEnterprise);
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
                return BadRequest("Percentage Update is missing some information");
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