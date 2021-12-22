using System.Collections.Generic;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietaryController : ControllerBase
    {
        private readonly IProprietaryService _proprietaryService;

        public ProprietaryController(IProprietaryService proprietaryService)
        {
            _proprietaryService = proprietaryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Proprietary>> GetAll()
        {
            return Ok(_proprietaryService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Proprietary> GetById(int id)
        {
            var proprietary = _proprietaryService.GetById(id);
            return Ok(new Proprietary()
            {
                Id = proprietary.Id,
                ProprietaryIdentificationNumber = proprietary.ProprietaryIdentificationNumber
            });
        }
    }
}