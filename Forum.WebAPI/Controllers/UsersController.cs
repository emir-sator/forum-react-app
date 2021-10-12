using Forum.WebAPI.Database;
using Forum.WebAPI.Dto;
using Forum.WebAPI.Exceptions;
using Forum.WebAPI.Helpers;
using Forum.WebAPI.Repositories.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace Forum.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        private readonly JwtService _jwtService;
        public UsersController(IUsersRepository usersRepository, JwtService jwtService) : base()
        {
            _usersRepository = usersRepository;
            _jwtService = jwtService;
        }

        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _usersRepository.GetUsers();
            return Ok(response);
        }

        //[Authorize]
        [HttpGet("SearchUsers")]
        public async Task<IActionResult> SearchUsers([FromQuery] string searchTerm)
        {
            var response = await _usersRepository.SearchUsers(searchTerm);
            return Ok(response);
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate(UsersToAuthenticateDto userToAuthenticateDto)
        {
            var user = await _usersRepository.GetByUsername(userToAuthenticateDto.Username);

            if (user == null)
            {
                throw new UserException("Invalid credentials");
            }
            if (user.Password != userToAuthenticateDto.Password)
            {
                throw new UserException("Invalid credentials");
            }

            var jwt = _jwtService.Generate(user.Id);

            Response.Cookies.Append("jwt", jwt, new Microsoft.AspNetCore.Http.CookieOptions { HttpOnly = true });
            return Ok(new
            {
                user
            });
        }

        [HttpGet("GetAuthenticatedUser")]
        public async Task<IActionResult> GetAuthenticatedUser()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = await _usersRepository.GetById(userId);

                return Ok(user);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete("jwt");

            return Ok("Logged out");
        }

    }
}
