using System;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IEachUidServices;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers.ForestDetailControllers.ForestUidControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForestUidController: ControllerBase
    {
        private readonly IForestUidService _forestUidService;

        public ForestUidController(IForestUidService forestUidService)
        {
            _forestUidService = forestUidService ?? throw new NullReferenceException("Forest Uid Service Can Not Be Null");
        }

        [HttpGet]
        public ActionResult GetAllFirstUids()
        {
            try
            {
                return Ok(_forestUidService.GetAllFirstUids());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
                
        }
        
        [HttpGet("SecondUid")]
        public ActionResult GetAllSecondUids()
        {
            try
            {
                return Ok(_forestUidService.GetAllSecondUids());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
                
        }
        
        [HttpGet("ThirdUid")]
        public ActionResult GetAllThirdUids()
        {
            try
            {
                return Ok(_forestUidService.GetAllThirdUids());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
                
        }
    }
}