using System;
using System.Collections.Generic;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.WebApi.Dtos.PercentageDto;
using IIAuctionHouse.WebApi.Dtos.TreeTypeDto;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PercentageController : Controller
    {
        private readonly IPercentageService _percentageService;

        public PercentageController(IPercentageService percentageService)
        {
            _percentageService = percentageService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(_percentageService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] PercentagePostDto percentage)
        {
            if (percentage.Value < 1)
                return BadRequest("Percentage Update is missing some information");
            try
            {
                var newPercentage = _percentageService.NewPercentage(percentage.Value);
                return Ok(_percentageService.Create(newPercentage));
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PercentageDto percentageDto)
        {
            if (id != percentageDto.Id)
                return BadRequest("Id needs to match in both url and object");
            if (percentageDto.Value < 1)
                return BadRequest("Percentage Update is missing some information");
            try
            {
                var percentageUpdate = _percentageService.NewPercentage(percentageDto.Value);
                return Ok(_percentageService.Update(percentageUpdate));
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
                return Ok(_percentageService.Delete(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}