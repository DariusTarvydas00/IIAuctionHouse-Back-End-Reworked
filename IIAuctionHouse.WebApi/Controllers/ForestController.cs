using System.Collections.Generic;
using IIAuctionHouse.Core.IServices.IForestService;
using IIAuctionHouse.Core.Models.Forest;
using IIAuctionHouse.DataAccess.Entities.ForestEntities;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForestController : Controller
    {
        private readonly IForestService _forestService;

        public ForestController(IForestService forestService)
        {
            _forestService = forestService;
        }

        [HttpGet]
        public ActionResult<List<Forest>> GetAll()
        {
            return _forestService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Forest> GetById(int id)
        {
            var foundForest = _forestService.GetById(id);
            return Ok(new Forest()
            {
                Id = foundForest.Id,
                ForestLocation = new ForestLocation()
                {
                    Id = foundForest.ForestLocation.Id
                },
                TreeGroup = new TreeGroup()
                {
                    Id = foundForest.TreeGroup.Id
                },
                TreeType = new TreeType()
                {
                    Id = foundForest.TreeType.Id
                }
            });
        }

        [HttpPost]
        public ActionResult<Forest> Post([FromBody] Forest forest)
        {
            return _forestService.Create(forest);
        }
        
        [HttpPut]
        public ActionResult<Forest> Put(ForestEntity forestEntity)
        {
            var update =_forestService.GetById(forestEntity.Id);
            return _forestService.Update(update);
        }

        [HttpDelete]
        public ActionResult<Forest> Delete(int id)
        {
            var deleteTypeOfTree = _forestService.Delete(id);
            return Ok(new Forest()
            {
                Id = deleteTypeOfTree.Id,
                ForestLocation = deleteTypeOfTree.ForestLocation,
                TreeGroup = deleteTypeOfTree.TreeGroup,
                TreeType = deleteTypeOfTree.TreeType
            });
        }
    }
}