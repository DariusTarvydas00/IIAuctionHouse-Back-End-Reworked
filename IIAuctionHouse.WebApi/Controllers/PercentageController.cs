using System;
using System.Collections.Generic;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.WebApi.Dtos;
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
        public ActionResult<List<Percentage>> GetAll()
        {
            return _percentageService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Percentage> GetById(int id)
        {
            var percentage = _percentageService.GetById(id);
            return Ok(percentage);
        }

        [HttpPost]
        public ActionResult<PercentageDto> Post([FromBody] PercentageDto percentageDto)
        {
            var newPercentage = _percentageService.NewPercentage(percentageDto.PercentageValue);
            return Ok(_percentageService.Create(newPercentage));
        }
        
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PercentageDto percentageDto)
        {
            var perc = _percentageService.GetById(id);
            var upd = new Percentage()
            {
                Id = perc.Id,
                PercentageValue = percentageDto.PercentageValue
            };
            return Ok(_percentageService.Update(upd));
        }

        [HttpDelete("{id}")]
        public ActionResult<PercentageDto> Delete(int id)
        {
            try
            {
                var deletePercentage = _percentageService.Delete(id);
                return Ok(deletePercentage);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}