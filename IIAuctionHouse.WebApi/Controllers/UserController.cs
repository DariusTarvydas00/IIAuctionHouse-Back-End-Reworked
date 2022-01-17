using System;
using System.IO;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IUserDetailServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.WebApi.Dto.UserDto;
using IIAuctionHouse.WebApi.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserDetailService _userDetailService;
        private readonly IAddressService _addressService;

        public UserController(IUserService userService, IUserDetailService userDetailService, IAddressService addressService)
        {
            _userService = userService ?? throw new InvalidDataException(UserControllerExceptions.ServiceIsNull);
            _userDetailService = userDetailService ?? throw new InvalidDataException(UserControllerExceptions.ServiceIsNull);
            _addressService = addressService ?? throw new InvalidDataException(UserControllerExceptions.ServiceIsNull);
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
            if (id < 1)
                return BadRequest(GeneralExceptions.IdNullOrLess);
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
        public ActionResult Post([FromBody] UserPostDto userPostDto)
        {
            if (userPostDto == null)
                return BadRequest(UserControllerExceptions.MissingSomeInformation); 
            try { 
                var newUserAddress = _addressService.NewAddress(userPostDto.UserDetailsPostDto.AddressPostDto.Country,userPostDto.UserDetailsPostDto.AddressPostDto.City,
                userPostDto.UserDetailsPostDto.AddressPostDto.StreetName,userPostDto.UserDetailsPostDto.AddressPostDto.StreetOrHouseNumber);
                var newUserDetail = _userDetailService.NewUserDetails(userPostDto.UserDetailsPostDto.Email, userPostDto.UserDetailsPostDto.PhoneNumber,
                    newUserAddress);
                var newUser = _userService.NewUser(userPostDto.FirstName, userPostDto.LastName, newUserDetail);
                return Ok(_userService.Create(newUser)); 
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPut]
        public ActionResult Put(int id, [FromBody]UserPutDto userPutDto)
        {
            if (userPutDto == null)
                return BadRequest(UserControllerExceptions.MissingSomeInformation);
            if (id != userPutDto.Id || id < 1)
                return BadRequest(GeneralExceptions.NotMatchingId);
            try
            {
                var newUserAddress = _addressService.NewAddress(userPutDto.UserDetailPutDto.AddressPutDto.Country,userPutDto.UserDetailPutDto.AddressPutDto.City,
                    userPutDto.UserDetailPutDto.AddressPutDto.StreetName,userPutDto.UserDetailPutDto.AddressPutDto.StreetOrHouseNumber);
                var newUserDetails = _userDetailService.NewUserDetails(userPutDto.UserDetailPutDto.Email, userPutDto.UserDetailPutDto.PhoneNumber,
                    newUserAddress);
                var newUser = _userService.UpdateUser(id,userPutDto.FirstName,userPutDto.LastName,newUserDetails);
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
            if (id < 1)
                return BadRequest(GeneralExceptions.IdNullOrLess);
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