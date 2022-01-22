using System;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IForestGroupServices.IGroupServices;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers.ForestDetailControllers.ForestGroupControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubGroupController: ControllerBase
    {
        private readonly ISubGroupService _subGroupService;

        public SubGroupController(ISubGroupService subGroupService)
        {
            _subGroupService = subGroupService ?? throw new NullReferenceException("Forest Sub Group Service Can Not Be Null");
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(_subGroupService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
                
        }
    }
}