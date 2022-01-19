using System;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IForestUidServices;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IPlotDetailServices;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IPlotDetailServices.ITreeTypeServices;
using IIAuctionHouse.WebApi.Dto.ForestDetailDto.PlotDetailsDto.PlotDto;
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
            if (id < 1)
                return BadRequest(ControllersExceptions.IdNullOrLess);
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
            if (plotPostDto == null)
                return BadRequest(ControllersExceptions.MissingSomeInformation);
            try
            {
                var newForestUidPostDto = _forestUidService.NewForestUid(
                    plotPostDto.ForestUidDto.ForestFirstUidDto.Id,
                    plotPostDto.ForestUidDto.ForestSecondUidDto.Id,
                    plotPostDto.ForestUidDto.ForestThirdUidDto.Id);
                var newTreeType = plotPostDto.TreeTypePostDtos.Select(dto =>
                    _treeTypeService.NewTreeType(dto.TreeTypeIdDto.Id, dto.PercentageIdDto.Id)).ToList();
                var newPlot = _plotService.NewPlot(plotPostDto.PlotSize, plotPostDto.PlotResolution, plotPostDto.PlotTenderness,
                    plotPostDto.Volume, plotPostDto.AverageTreeHeight, newTreeType, newForestUidPostDto);
                return Ok(_plotService.Create(newPlot));
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PlotPutDto plotPut)
        {
            if (plotPut == null)
                return BadRequest(ControllersExceptions.MissingSomeInformation);
            if (id != plotPut.Id || id < 1)
                return BadRequest(ControllersExceptions.NotMatchingId);
            try
            {
                var newForestUidPostDto = _forestUidService.UpdateForestUid(
                    plotPut.ForestUidDto.Id,
                    plotPut.ForestUidDto.ForestFirstUidDto.Id,
                    plotPut.ForestUidDto.ForestSecondUidDto.Id,
                    plotPut.ForestUidDto.ForestThirdUidDto.Id);
                var newTreeType = plotPut.TreeTypeDtos.Select(dto =>
                    _treeTypeService.UpdateTreeType( dto.Id, dto.TreeTypeIdDto.Id, dto.PercentageIdDto.Id)).ToList();
                var plotUpdate = _plotService.UpdatePlot(plotPut.Id, plotPut.PlotSize, plotPut.PlotResolution, plotPut.PlotTenderness,
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
            if (id < 1)
                return BadRequest(ControllersExceptions.IdNullOrLess);
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