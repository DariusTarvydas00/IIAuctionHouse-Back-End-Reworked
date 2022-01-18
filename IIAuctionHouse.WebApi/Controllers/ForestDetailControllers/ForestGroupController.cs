﻿using System;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestDetailServices;
using IIAuctionHouse.WebApi.Dto.ForestDetailDto.ForestGroupDto;
using IIAuctionHouse.WebApi.Exceptions;
using IIAuctionHouse.WebApi.Exceptions.ForestDetailsControllersExceptions;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers.ForestDetailControllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class ForestGroupController : ControllerBase
        {
            private readonly IForestGroupService _forestGroupService;

            public ForestGroupController(IForestGroupService forestGroupService)
            {
                _forestGroupService = forestGroupService ?? throw new InvalidDataException(ForestGroupControllerExceptions.ServiceIsNull);
            }

            [HttpGet]
            public ActionResult GetAll()
            {
                try
                {
                    return Ok(_forestGroupService.GetAll());
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
                
            }

            [HttpPost]
            public ActionResult Post([FromBody] ForestGroupPostDto forestGroup)
            {
                if (string.IsNullOrEmpty(forestGroup.Name) || forestGroup.Name.Any(char.IsDigit))
                    return BadRequest(ForestGroupControllerExceptions.InvalidName);
                try
                {
                    var newForestGroup = _forestGroupService.NewForestGroup(forestGroup.Name);
                    return Ok(_forestGroupService.Create(newForestGroup));
                }
                catch(Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            
            [HttpPut("{id}")]
            public ActionResult Put(int id, [FromBody] ForestGroupPutDto treePutDto)
            {
                if (id != treePutDto.Id || id < 1)
                    return BadRequest(GeneralExceptions.NotMatchingId);
                if (string.IsNullOrEmpty(treePutDto.Name) || treePutDto.Name.Any(char.IsDigit))
                    return BadRequest(ForestGroupControllerExceptions.InvalidName);
                try
                {
                    var treeTypeUpdate = _forestGroupService.UpdateForestGroup(treePutDto.Id, treePutDto.Name);
                    return Ok(_forestGroupService.Update(treeTypeUpdate));
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
                    return Ok(_forestGroupService.Delete(id));
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
        }
    }