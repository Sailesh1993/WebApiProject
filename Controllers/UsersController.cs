using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProject.Dto;
using WebProject.Services.Abstractions;

namespace WebProject.Controllers
{
    [ApiController]
    [Authorize] //applied in all routes inside the controller
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
         public UsersController(IUserService userService)
         {
            _userService = userService;
         }

         [Authorize] //only applied in the assigned route and method
         [HttpGet("{id:Guid}")]
         [ProducesResponseType(statusCode:500)]
         [ProducesResponseType(statusCode:200)]

         public ActionResult<UserDto> GetUserById(Guid id)
         {
            var foundUser = _userService.GetUserById(id);
            if(foundUser == null)
            {
               return NotFound();
            }
            return _userService.GetUserById(id);
         }

         [HttpPost()]
         public UserDto CreateUser([FromBody] UserDto userDto)
         {
            return _userService.CreateUser(userDto);
         }
         [HttpPatch("{id:Guid}")]
         public UserDto UpdateUser([FromRoute] Guid id, [FromBody] UserDto update)
         {
            return _userService.UpdateUser(id, update);
         }
    }
}