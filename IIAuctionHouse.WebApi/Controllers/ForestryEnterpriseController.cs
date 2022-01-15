using System;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.WebApi.Dtos.ForestDto;
using IIAuctionHouse.WebApi.Dtos.ForestryEnterpriseDto;
using IIAuctionHouse.WebApi.Dtos.PlotDto;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForestryEnterpriseController : Controller
    {
        private readonly IForestEnterpriseService _forestEnterpriseService;

        public ForestryEnterpriseController(IForestEnterpriseService forestEnterpriseService)
        {
            _forestEnterpriseService = forestEnterpriseService;
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

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                return Ok(_forestEnterpriseService.GetById(id));
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] ForestryEnterprisePostDto forestryEnterprisePostDto)
        {
            try
            {
                var newForestEnterprise = _forestEnterpriseService.NewForestEnterprise(forestryEnterprisePostDto.Name);
                return Ok(_forestEnterpriseService.Create(newForestEnterprise));
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ForestryEnterprise forestryEnterprise)
        {
            if (id != forestryEnterprise.Id)
                return BadRequest("Id needs to match in both url and object");
            try
            {
                return Ok(_forestEnterpriseService.Update(forestryEnterprise));
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