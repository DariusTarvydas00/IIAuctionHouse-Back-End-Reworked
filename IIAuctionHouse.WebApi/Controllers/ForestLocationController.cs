using System.Collections.Generic;
using IIAuctionHouse.Core.IServices.IForestService;
using IIAuctionHouse.Core.Models.Forest;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForestLocationController : ControllerBase
    {
        private readonly IForestLocationService _forestLocationService;

        public ForestLocationController(IForestLocationService forestLocationService)
        {
            _forestLocationService = forestLocationService;
        }

        [HttpGet]
        public ActionResult<List<ForestLocation>> GetAll()
        {
            return _forestLocationService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<ForestLocation> GetById(int id)
        {
            var forestLocation = _forestLocationService.GetById(id);
            return Ok(new ForestLocation()
            {
                Id = forestLocation.Id,
                ForestryEnterprise = forestLocation.ForestryEnterprise
            });
        }
        
        [HttpPost]
        public ActionResult<ForestLocation> Post(string forestLocation)
        {
            var postForestLocation = _forestLocationService.Create(forestLocation);
            return Ok(new ForestLocation()
            {
                Id = postForestLocation.Id,
                ForestryEnterprise = postForestLocation.ForestryEnterprise
            });
        }
        
        [HttpPut]
        public ActionResult<Forest> Put(string forestLocation)
        {
            return null;
        }
        
        [HttpDelete]
        public ActionResult<ForestLocation> Delete(int id)
        {
            var deleteForestLocation = _forestLocationService.Delete(id);
            return Ok(new ForestLocation()
            {
                Id = deleteForestLocation.Id,
                ForestryEnterprise = deleteForestLocation.ForestryEnterprise
            });
        }
    }
}