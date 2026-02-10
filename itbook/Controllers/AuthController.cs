using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;
using Humanizer;
using itbook.Data;
using itbook.Dtos;
using itbook.Interfaces;
using itbook.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace itbook.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ITokenService _tokenService;

        public AuthController(ApplicationDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<UserDto>> Register(
            [FromBody] RegisterRequestDto registerRequestDto
        )
        {
            // Check if username already exists in db, if not return 400
            var existingUser = await _context.Users.FirstOrDefaultAsync(u =>
                u.Username == registerRequestDto.Username
            );
            if (existingUser != null)
            {
                return BadRequest("Username already exists");
            }
            // Hash password
            var user = registerRequestDto.ToUserFromCreateDto();
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            // Save user to db
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            // Response user created
            return Created("", user.ToUserDto());
        }

        [HttpPost("login")]
        public async Task<ActionResult<dynamic>> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            // Check if username exists in db, if not return 404
            var user = await _context.Users.FirstOrDefaultAsync(u =>
                u.Username == loginRequestDto.Username
            );
            if (user == null)
            {
                return NotFound("User not found");
            }
            // Check if password is correct, if not return 401
            if (!BCrypt.Net.BCrypt.Verify(loginRequestDto.Password, user.Password))
            {
                return Unauthorized("Password is incorrect");
            }
            // Response token
            return Ok(new { token = _tokenService.CreateToken(user) });
        }
    }
}
