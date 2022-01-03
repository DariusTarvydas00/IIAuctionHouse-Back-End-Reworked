using System.Collections.Generic;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.WebApi.Dtos;
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
        public ActionResult<List<Plot>> GetAll()
        {
            return _plotService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Plot> GetById(int id)
        {
            var foundPlot = _plotService.GetById(id);
            return Ok(foundPlot);
        }

        [HttpPost]
        public ActionResult<PlotDto> Post([FromBody] PlotDto plotDto)
        {
            var plotie = _plotService.NewPlot(plotDto.PlotSize, plotDto.PlotResolution, plotDto.PlotTenderness,
                plotDto.Volume, plotDto.AverageTreeHeight,  plotDto.TreeTypes);
            return Ok(_plotService.Create(plotie));
        }

        [HttpPut("{id}")]
        public ActionResult<Plot> Put(int id, [FromBody] PlotDto plot)
        {
            var update = _plotService.GetById(id);
            var upd = new Plot()
            {
                Id = update.Id,
                Volume = plot.Volume,
                PlotResolution = plot.PlotResolution,
                PlotSize = plot.PlotSize,
                PlotTenderness = plot.PlotTenderness,
                AverageTreeHeight = plot.AverageTreeHeight,
                TreeTypes = plot.TreeTypes
            };
            return _plotService.Update(upd);
        }

        [HttpDelete]
        public ActionResult<Plot> Delete(int id)
        {
            var deleteTypeOfTree = _plotService.Delete(id);
            return Ok(deleteTypeOfTree);
        }
    }
}