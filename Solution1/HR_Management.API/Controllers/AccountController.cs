﻿using HR_Management.Application.Contracts.Identity;
using HR_Management.Application.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _authService.login(request));
        }
        [HttpPost("register")]
        public async Task<ActionResult<RegistrationRequest>> Login(RegistrationRequest request)
        {
            return Ok(await _authService.register(request));
        }
    }
}
