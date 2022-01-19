using System;
using System.IO;
using IIAuctionHouse.Core.IServices.IForestDetailServices;
using IIAuctionHouse.WebApi.Dto.ForestDetailDto.ForestryEnterpriseDto;
using IIAuctionHouse.WebApi.Exceptions;
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
            _forestEnterpriseService = forestEnterpriseService ?? throw new InvalidDataException(ControllersExceptions.NullService);
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
                if (id < 1)
                    throw new InvalidDataException(ControllersExceptions.IdNullOrLess);
                return Ok(_forestEnterpriseService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] ForestryEnterprisePostDto forestryEnterprisePostDto)
        {
            try
            {
                return Ok(_forestEnterpriseService
                    .Create(_forestEnterpriseService
                        .NewForestryEnterprise(forestryEnterprisePostDto.Name)));
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ForestryEnterprisePutDto forestryEnterprise)
        {
            try
            {
                if (id < 1)
                    throw new InvalidDataException(ControllersExceptions.IdNullOrLess);
                return Ok(_forestEnterpriseService
                    .Update(_forestEnterpriseService
                        .NewForestryEnterprise(forestryEnterprise.Id, forestryEnterprise.Name)));
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
                if (id < 1)
                    return BadRequest(ControllersExceptions.IdNullOrLess);
                return Ok(_forestEnterpriseService.Delete(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}