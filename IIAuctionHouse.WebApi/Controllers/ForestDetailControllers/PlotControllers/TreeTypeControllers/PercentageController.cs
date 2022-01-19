using System;
using System.IO;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IPlotDetailServices.ITreeTypeServices;
using IIAuctionHouse.WebApi.Dto.ForestDetailDto.PlotDetailsDto.TreeTypesDto;
using IIAuctionHouse.WebApi.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers.ForestDetailControllers.PlotControllers.TreeTypeControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PercentageController : Controller
    {
        private readonly IPercentageService _percentageService;

        public PercentageController(IPercentageService percentageService)
        {
            _percentageService = percentageService ?? throw new InvalidDataException(ControllersExceptions.NullService);
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
        public ActionResult Post([FromBody] PercentageDto percentage)
        {
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
        public ActionResult Put(int id, [FromBody] PercentageDto percentage)
        {
            try
            {
                var percentageUpdate = _percentageService.NewPercentage(percentage.Id, percentage.Value);
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