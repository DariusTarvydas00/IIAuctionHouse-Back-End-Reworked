﻿using System;
using System.Linq;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.WebApi.Dtos.TreeDto;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class TreeController : ControllerBase
        {
            private readonly ITreeService _treeService;

            public TreeController(ITreeService treeService)
            {
                _treeService = treeService;
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
            public ActionResult Post([FromBody] TreePostDto treeDto)
            {
                if (string.IsNullOrEmpty(treeDto.Name))
                    return BadRequest("Tree to Update is missing some information");
                try
                {
                    var newTreeType = _treeService.NewTree(treeDto.Name);
                    return Ok(_treeService.Create(newTreeType));
                }
                catch(Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            
            [HttpPut("{id}")]
            public ActionResult Put(int id, [FromBody] TreePutDto treePutDto)
            {
                if (id != treePutDto.Id || id < 1)
                    return BadRequest("Id needs to match in both url and object");
                if (string.IsNullOrEmpty(treePutDto.Name) || treePutDto.Name.Any(char.IsDigit))
                    return BadRequest("Tree to Update is missing some information");
                Console.WriteLine(id+" "+ treePutDto.Id + " " + treePutDto.Name);
                try
                {
                    var treeTypeUpdate = _treeService.UpdateTree(treePutDto.Id, treePutDto.Name);
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