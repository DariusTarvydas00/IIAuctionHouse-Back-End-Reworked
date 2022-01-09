﻿using System;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.WebApi.Dtos.PercentageDto;
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
        public ActionResult Put(int id, [FromBody] PercentagePutDto percentagePutDto)
        {
            if (id != percentagePutDto.Id)
                return BadRequest("Id needs to match in both url and object");
            if (percentagePutDto.Value < 1 || id < 1)
                return BadRequest("Percentage Update is missing some information");
            try
            {
                var percentageUpdate = _percentageService.UpdatePercentage(percentagePutDto.Id,percentagePutDto.Value);
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
            if (id < 1)
                return BadRequest("Percentage Update is missing some information");
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