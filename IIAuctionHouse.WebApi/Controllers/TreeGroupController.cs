using System.Collections.Generic;
using IIAuctionHouse.Core.IServices.IForestService;
using IIAuctionHouse.Core.Models.Forest;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeGroupController : ControllerBase
    {
        private readonly ITreeGroupService _treeGroupService;

        public TreeGroupController(ITreeGroupService treeGroupService)
        {
            _treeGroupService = treeGroupService;
        }

        [HttpGet]
        public ActionResult<List<TreeGroup>> GetAll()
        {
            return _treeGroupService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<TreeGroup> GetById(int id)
        {
            var foundTreeGroup = _treeGroupService.GetById(id);
            return Ok(new TreeGroup()
            {
                Id = foundTreeGroup.Id,
                GroupOfTree = foundTreeGroup.GroupOfTree
            });
        }
        
        [HttpPost]
        public ActionResult<TreeGroup> Post(string groupOfTree)
        {
            var postGroupOfTree = _treeGroupService.Create(groupOfTree);
            return Ok(new TreeGroup()
            {
                Id = postGroupOfTree.Id,
                GroupOfTree = postGroupOfTree.GroupOfTree
            });
        }
        
        [HttpDelete]
        public ActionResult<TreeGroup> Delete(int id)
        {
            var deleteGroupOfTree = _treeGroupService.Delete(id);
            return Ok(new TreeGroup()
            {
                Id = deleteGroupOfTree.Id,
                GroupOfTree = deleteGroupOfTree.GroupOfTree
            });
        }
    }
}