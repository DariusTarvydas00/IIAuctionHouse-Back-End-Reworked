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
            return Ok(new Plot()
            {
                Id = foundPlot.Id,
                // TreeType = new TreeType()
                // {
                //     Id = foundForest.TreeType.Id
                // }
            });
        }

        [HttpPost]
        public ActionResult<Plot> Post([FromBody] Plot plot)
        {
            return _plotService.Create(plot);
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
            return Ok(new Plot()
            {
                Id = deleteTypeOfTree.Id,
                //TreeType = deleteTypeOfTree.TreeType
            });
        }
    }
}