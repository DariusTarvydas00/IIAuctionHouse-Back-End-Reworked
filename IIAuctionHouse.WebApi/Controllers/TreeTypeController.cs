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
            public ActionResult<TreeTypeDto> GetById(int id)
            {
                var treeType = _treeTypeService.GetById(id);
                return Ok(treeType);
            }

            [HttpPost]
            public ActionResult<TreeType> Post([FromBody] TreeTypeDto treeTypeDto)
            {
                var newTreeType = _treeTypeService.NewTreeType(treeTypeDto.Name, treeTypeDto.Percentage);
                _treeTypeService.Create(newTreeType);
                return Ok(newTreeType);
            }

            [HttpDelete("{id}")]
            public ActionResult<TreeType> Delete(int id)
            {
                var deleteTreeType = _treeTypeService.Delete(id);
                return Ok(deleteTreeType);
            }
        }
    }