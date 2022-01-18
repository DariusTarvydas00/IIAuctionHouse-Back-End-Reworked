﻿using System;
using System.IO;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IForestUidServices;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;
using IIAuctionHouse.WebApi.Dto.ForestDetailDto.ForestUidDto;
using IIAuctionHouse.WebApi.Exceptions;
using IIAuctionHouse.WebApi.Exceptions.ForestDetailsControllersExceptions.ForestUidControllersExceptions;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers.ForestDetailControllers.ForestUidControllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class ForestSecondUidController : ControllerBase
        {
            private readonly IForestSecondUidService _forestSecondUidService;

            public ForestSecondUidController(IForestSecondUidService forestSecondUidService)
            {
                _forestSecondUidService = forestSecondUidService ?? throw new InvalidDataException(ForestUidControllerException.ServiceIsNull);
            }

            [HttpGet]
            public ActionResult GetAll()
            {
                try
                {
                    return Ok(_forestSecondUidService.GetAll());
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
                
            }

            [HttpPost]
            public ActionResult Post([FromBody] ForestUidPostFstDto forestUidPostDto)
            {
                if (forestUidPostDto.Value is < 1 or > 9999)
                    return BadRequest(ForestUidControllerException.ValueNotInRange);
                try
                {
                    var newForestSecondUid = _forestSecondUidService.NewSecondUid(forestUidPostDto.Value);
                    return Ok(_forestSecondUidService.Create(newForestSecondUid));
                }
                catch(Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            
            [HttpPut("{id}")]
            public ActionResult Put(int id, [FromBody] ForestUidSecond forestUidSecond)
            {
                if (id != forestUidSecond.Id || id < 1)
                    return BadRequest(GeneralExceptions.NotMatchingId);
                if (forestUidSecond.Value is < 1 or > 9999)
                    return BadRequest(ForestUidControllerException.ValueNotInRange);
                try
                {
                    var treeTypeUpdate = _forestSecondUidService.UpdateSecondUid(forestUidSecond.Id, forestUidSecond.Value);
                    return Ok(_forestSecondUidService.Update(treeTypeUpdate));
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
                    return Ok(_forestSecondUidService.Delete(id));
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
        }
}