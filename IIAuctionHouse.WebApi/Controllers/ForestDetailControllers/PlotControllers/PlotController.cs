using System;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IForestUidServices;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IPlotDetailServices;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IPlotDetailServices.ITreeTypeServices;
using IIAuctionHouse.WebApi.Dto.ForestDetailDto.PlotDetailsDto;
using IIAuctionHouse.WebApi.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers.ForestDetailControllers.PlotControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlotController : Controller
    {
        private readonly IPlotService _plotService;
        private readonly IForestUidService _forestUidService;
        private readonly ITreeTypeService _treeTypeService;

        public PlotController(IPlotService plotService, IForestUidService forestUidService, ITreeTypeService treeTypeService)
        {
            _plotService = plotService ?? throw new InvalidDataException(ControllersExceptions.NullService);
            _forestUidService = forestUidService ?? throw new InvalidDataException(ControllersExceptions.NullService);
            _treeTypeService = treeTypeService ?? throw new InvalidDataException(ControllersExceptions.NullService);
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
        public ActionResult Post([FromBody] PlotDto plotDto)
        {
            try
            {
                var newForestUidPostDto = _forestUidService.NewForestUid(
                    plotDto.ForestUid.ForestFirstUidDto.Id,
                    plotDto.ForestUid.ForestSecondUidDto.Id,
                    plotDto.ForestUid.ForestThirdUidDto.Id);
                var newTreeType = plotDto.TreeTypes.Select(dto =>
                    _treeTypeService.NewTreeType(dto.Id,dto.Tree.Id, dto.Percentage.Id)).ToList();
                var newPlot = _plotService.NewPlot(plotDto.Id,plotDto.PlotSize, plotDto.PlotResolution, plotDto.PlotTenderness,
                    plotDto.Volume, plotDto.AverageTreeHeight, newTreeType, newForestUidPostDto);
                return Ok(_plotService.Create(newPlot));
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PlotDto plotPut)
        {
            try
            {
                var newForestUidPostDto = _forestUidService.UpdateForestUid(
                    plotPut.ForestUid.Id,
                    plotPut.ForestUid.ForestFirstUidDto.Id,
                    plotPut.ForestUid.ForestSecondUidDto.Id,
                    plotPut.ForestUid.ForestThirdUidDto.Id);
                var newTreeType = plotPut.TreeTypes.Select(dto =>
                    _treeTypeService.NewTreeType(plotPut.Id, dto.Tree.Id, dto.Percentage.Id)).ToList();
                var plotUpdate = _plotService.NewPlot(plotPut.Id, plotPut.PlotSize, plotPut.PlotResolution, plotPut.PlotTenderness,
                    plotPut.Volume, plotPut.AverageTreeHeight, newTreeType, newForestUidPostDto);
                return Ok(_plotService.Update(plotUpdate));
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