﻿using System;
using System.IO;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IPlotDetailServices.ITreeTypeServices;
using IIAuctionHouse.WebApi.Dto.ForestDetailDto.PlotDetailsDto.TreeTypeDto;
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
                _treeService = treeService ?? throw new InvalidDataException(ControllersExceptions.NullService);
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
            public ActionResult Post([FromBody] TreeDto tree)
            {
                try
                {
                    var newTreeType = _treeService.NewTree(tree.Name);
                    return Ok(_treeService.Create(newTreeType));
                }
                catch(Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            
            [HttpPut("{id}")]
            public ActionResult Put(int id, [FromBody] TreeDto tree)
            {
                try
                {
                    var treeTypeUpdate = _treeService.NewTree(tree.Id, tree.Name);
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