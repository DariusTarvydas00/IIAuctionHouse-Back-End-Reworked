using System;
using IIAuctionHouse.Core.IServices.IForestDetailServices;
using IIAuctionHouse.WebApi.Dto.PlotDtos;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers.ForestDetailControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlotController : Controller
    {
        private readonly IPlotService _plotService;

        public PlotController(IPlotService plotService)
        {
            _plotService = plotService ?? throw new NullReferenceException("Plot Service Can Not Be Null");
        }

        [HttpPost]
        public ActionResult Post([FromBody] PlotDto plotDto)
        {
            // foreach (var treeType in plotDto.TreeTypes)
            // {
            //     Console.WriteLine(treeType.Tree.Id);
            //     Console.WriteLine(treeType.Percentage.Id);
            // }
            try
            {
                var newPlot = _plotService.NewPlot(plotDto.ForestId, plotDto.Volume,
                    plotDto.AverageTreeHeight, plotDto.PlotSize, plotDto.PlotTenderness, plotDto.PlotResolution,
                    plotDto.TreeTypes);
                return Ok(_plotService.Create(newPlot));
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public ActionResult Put(int id, [FromBody] PlotDto plotDto)
        {
            if (id != plotDto.Id)
                throw new Exception("Id Does Not Match");
            try
            {
                var newPlot = _plotService.NewPlot( plotDto.ForestId, plotDto.Volume,
                    plotDto.AverageTreeHeight, plotDto.PlotSize, plotDto.PlotTenderness, plotDto.PlotResolution,
                    plotDto.TreeTypes);
                return Ok(_plotService.Update(newPlot));
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
                return Ok(_plotService.Delete(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}