using System;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IForestGroupServices.IGroupServices;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers.ForestDetailControllers.ForestGroupControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController: ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService ?? throw new NullReferenceException("Forest Group Service Can Not Be Null");
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(_groupService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
                
        }
        
    }
}