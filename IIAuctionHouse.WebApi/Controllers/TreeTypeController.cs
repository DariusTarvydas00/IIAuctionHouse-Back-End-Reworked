using System.Collections.Generic;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class TreeTypeController : ControllerBase
        {
            private readonly ITreeTypeService _treeTypeService;
            private readonly IPercentageService _percentageService;

            public TreeTypeController(ITreeTypeService treeTypeService)
            {
                _treeTypeService = treeTypeService;
            }

            [HttpGet]
            public ActionResult<List<TreeType>> GetAll()
            {
                return _treeTypeService.GetAll();
            }

            [HttpGet("{id}")]
            public ActionResult<TreeType> GetById(int id)
            {
                var treeType = _treeTypeService.GetById(id);
                return Ok(treeType);
            }

            [HttpPost]
            public ActionResult<TreeTypeDto> Post([FromBody] TreeTypeDto treeTypeDto)
            {
                return Ok(_treeTypeService.Create(new TreeType()
                {
                    Name = treeTypeDto.Name,
                    Percentage = new Percentage()
                    {
                        Id = treeTypeDto.PercentageId
                    }
                }));
            }
            
            [HttpPut("{id}")]
            public ActionResult Put(int id, [FromBody] TreeTypeDto treeTypeDto)
            {
                var foundTreeType = _treeTypeService.GetById(id);
                var treeType = new TreeType()
                {
                    Id = foundTreeType.Id,
                    Name = treeTypeDto.Name,
                    Percentage = new Percentage()
                    {
                        Id = treeTypeDto.PercentageId
                    }
                };
                return Ok(_treeTypeService.Update(treeType));
            }

            [HttpDelete("{id}")]
            public ActionResult<TreeTypeDto> Delete(int id)
            {
                var deleteTreeType = _treeTypeService.Delete(id);
                return Ok(deleteTreeType);
            }
        }
    }