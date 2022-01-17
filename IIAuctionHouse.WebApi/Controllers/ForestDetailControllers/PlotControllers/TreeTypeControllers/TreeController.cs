using System;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IPlotDetailServices.ITreeTypeServices;
using IIAuctionHouse.WebApi.Dto.ForestDetailDto.PlotDetailsDtos.TreeTypeDto.TreeDto;
using IIAuctionHouse.WebApi.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers.ForestDetailControllers.PlotControllers.TreeTypeControllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class TreeController : ControllerBase
        {
            private readonly ITreeService _treeService;

            public TreeController(ITreeService treeService)
            {
                _treeService = treeService ?? throw new InvalidDataException(ControllersExceptions.ServiceIsNull);
            }

            [HttpGet]
            public ActionResult GetAll()
            {
                try
                {
                    return Ok(_treeService.GetAll());
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
                
            }

            [HttpPost]
            public ActionResult Post([FromBody] TreePostDto treeDto)
            {
                if (string.IsNullOrEmpty(treeDto.Name) || treeDto.Name.Any(char.IsDigit))
                    return BadRequest(ControllersExceptions.InvalidName);
                try
                {
                    var newTreeType = _treeService.NewTree(treeDto.Name);
                    return Ok(_treeService.Create(newTreeType));
                }
                catch(Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            
            [HttpPut("{id}")]
            public ActionResult Put(int id, [FromBody] TreePutDto treePutDto)
            {
                if (id != treePutDto.Id || treePutDto.Id < 1 || id < 1 )
                    return BadRequest(GeneralExceptions.NotMatchingId);
                try
                {
                    var treeTypeUpdate = _treeService.UpdateTree(treePutDto.Id, treePutDto.Name);
                    return Ok(_treeService.Update(treeTypeUpdate));
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
                    return Ok(_treeService.Delete(id));
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
        }
    }