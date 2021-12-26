using System.Collections.Generic;
using IIAuctionHouse.Core.IServices.IForestService;
using IIAuctionHouse.Core.Models.Forest;
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
            public ActionResult<TreeType> GetById(int id)
            {
                var foundTreeType = _treeTypeService.GetById(id);
                return Ok(new TreeType()
                {
                    Id = foundTreeType.Id,
                    TypeOfTree = foundTreeType.TypeOfTree
                });
            }

            [HttpPost]
            public ActionResult<TreeType> Post(string typeOfTree)
            {
                var postTypeOfTree = _treeTypeService.Create(typeOfTree);
                return Ok(new TreeType()
                {
                    Id = postTypeOfTree.Id,
                    TypeOfTree = postTypeOfTree.TypeOfTree
                });
            }

            [HttpDelete]
            public ActionResult<TreeType> Delete(int id)
            {
                var deleteTypeOfTree = _treeTypeService.Delete(id);
                return Ok(new TreeType()
                {
                    Id = deleteTypeOfTree.Id,
                    TypeOfTree = deleteTypeOfTree.TypeOfTree
                });
            }
        }
    }