using System;
using IIAuctionHouse.Core.IServices.IForestDetailServices.ITreeTypeServices.TTServices;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers.ForestDetailControllers.TreeTypes
{
    [Route("api/[controller]")]
    [ApiController]
    public class PercentageController: ControllerBase
    {
        
        private readonly IPercentageService _percentageService;

        public PercentageController(IPercentageService percentageService)
        {
            _percentageService = percentageService ?? throw new NullReferenceException("Percentage Service Can Not Be Null");
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
    }
}