using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.WebApi.Dtos.PlotDto;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlotController : Controller
    {
        private readonly IPlotService _plotService;

        public PlotController(IPlotService plotService)
        {
            _plotService = plotService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(_plotService.GetAll());
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
                return Ok(_plotService.GetById(id));
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] PlotPostDto plotPostDto)
        {
            try
            {
                var newPlot = _plotService.NewPlot(plotPostDto.PlotSize, plotPostDto.PlotResolution, plotPostDto.PlotTenderness,
                    plotPostDto.Volume, plotPostDto.AverageTreeHeight,  plotPostDto.TreeTypeDto);
                return Ok(_plotService.Create(newPlot));
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PlotPutDto plotPost)
        {
            if (id != plotPost.Id)
                return BadRequest("Id needs to match in both url and object");
            try
            {
                var plotUpdate = _plotService.UpdatePlot(plotPost.Id, plotPost.PlotSize, plotPost.PlotResolution, plotPost.PlotTenderness,
                    plotPost.Volume, plotPost.AverageTreeHeight,  plotPost.TreeTypeDto);
                return Ok(_plotService.Update(plotUpdate));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                return Ok(_plotService.Delete(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}