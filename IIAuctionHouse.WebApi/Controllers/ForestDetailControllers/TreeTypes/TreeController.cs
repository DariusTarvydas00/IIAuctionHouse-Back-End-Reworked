using System;
using IIAuctionHouse.Core.IServices.IForestDetailServices.ITreeTypeServices.TTServices;
using IIAuctionHouse.Core.Models.ForestDetailModels.TreeTypes.TTModels;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers.ForestDetailControllers.TreeTypes
{
    [Route("api/[controller]")]
    [ApiController]
        public class TreeController : ControllerBase
        {
            private readonly ITreeService _treeService;

            public TreeController(ITreeService treeService)
            {
                _treeService = treeService ?? throw new NullReferenceException("Tree Service Can Not Be Null");
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
            public ActionResult Post([FromBody] Tree tree)
            {
                try
                {
                    return Ok(_treeService.Create(tree));
                }
                catch(Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            
            [HttpPut("{id}")]
            public ActionResult Put(int id, [FromBody] Tree tree)
            {
                try
                {
                    return Ok(_treeService.Update(id, tree));
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