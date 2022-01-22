using System;
using System.IO;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.WebApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new InvalidDataException("");
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(_userService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                return Ok(_userService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] UserDto userDto)
        {
            try { 
               
                var newUser = _userService.NewUser(userDto.Id,userDto.FirstName, userDto.LastName, userDto.UserDetails, userDto.ForestUid);
                return Ok(_userService.Create(newUser)); 
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPut]
        public ActionResult Put([FromBody]UserDto userDto)
        {
            try
            {
                var newUser = _userService.NewUser(userDto.Id,userDto.FirstName, userDto.LastName, userDto.UserDetails, userDto.ForestUid);
                return Ok(_userService.Update(newUser));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                return Ok(_userService.Delete(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}