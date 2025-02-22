﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shapping.api.Entities;
using Shapping.api.Models;
using Shapping.api.Services;
using System.Collections.Generic;

namespace Shapping.api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/authentication")]
    public class authenticationController : ControllerBase
    {
        private readonly IUserService _userService;

        public authenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public User Login([FromBody] UserDto user)
        {
            var User = _userService.Authenticate(user.Username, user.Password);

            return User;
        }

        [Authorize(Policy = "GetAllUser")]
        [HttpGet("all")]
        public IEnumerable<User> GetAllUser()
        {
            return _userService.GetAll();
        }
    }
}
