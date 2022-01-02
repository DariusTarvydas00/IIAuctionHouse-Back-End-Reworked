using System.Collections.Generic;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
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
        public ActionResult<Plot> Post([FromBody] Plot plot)
        {
            var newPlot = _plotService.NewPlot(plot.Volume, plot.PlotResolution,
                plot.PlotTenderness, plot.Volume, plot.AverageTreeHeight, plot.TreeTypes);
            return _plotService.Create(newPlot);
        }

        [HttpPut]
        public ActionResult<Plot> Put(Plot plot)
        {
            var update = _plotService.GetById(plot.Id);
            return _plotService.Update(update);
        }

        [HttpDelete]
        public ActionResult<Plot> Delete(int id)
        {
            var deleteTypeOfTree = _plotService.Delete(id);
            return Ok(deleteTypeOfTree);
        }
    }
}