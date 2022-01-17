using System;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestDetailServices;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.WebApi.Dto.ForestDetailDto.ForestryEnterpriseDto;
using IIAuctionHouse.WebApi.Exceptions;
using IIAuctionHouse.WebApi.Exceptions.ForestDetailsControllersExceptions;
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
            _forestEnterpriseService = forestEnterpriseService ?? throw new InvalidDataException(ForestryEnterpriseControlletExceptions.ServiceIsNull);
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
        public ActionResult Post([FromBody] ForestryEnterprisePostDto forestryEnterprisePostDto)
        {
            if (string.IsNullOrEmpty(forestryEnterprisePostDto.Name) || forestryEnterprisePostDto.Name.Any(char.IsDigit))
                return BadRequest(ForestryEnterpriseControlletExceptions.InvalidName);
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
            if (forestryEnterprise == null)
                return BadRequest(ForestryEnterpriseControlletExceptions.MissingSomeInformation);
            if (id != forestryEnterprise.Id || id < 1)
                return BadRequest(GeneralExceptions.NotMatchingId);
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
            if (id < 1)
                return BadRequest(GeneralExceptions.IdNullOrLess);
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