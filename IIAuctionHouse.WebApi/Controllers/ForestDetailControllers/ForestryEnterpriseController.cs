using System;
using IIAuctionHouse.Core.IServices.IForestDetailServices;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers.ForestDetailControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForestryEnterpriseController : Controller
    {
        private readonly IForestEnterpriseService _forestEnterpriseService;

        public ForestryEnterpriseController(IForestEnterpriseService forestEnterpriseService)
        {
            _forestEnterpriseService = forestEnterpriseService ?? throw new NullReferenceException("Forestry Enterprise Service Can Not Be Null");
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(_forestEnterpriseService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] ForestryEnterprise forestryEnterprise)
        {
            try
            {
                return Ok(_forestEnterpriseService.Create(forestryEnterprise));
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id,[FromBody] ForestryEnterprise forestryEnterprise)
        {
            try
            {
                return Ok(_forestEnterpriseService.Update(id, forestryEnterprise));
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
                return Ok(_forestEnterpriseService.Delete(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}