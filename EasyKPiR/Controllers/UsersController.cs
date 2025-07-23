using EasyKPiR.Application.DTOs;
using EasyKPiR.Application.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyKPiR.Api.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowLocalhost")]
    public class UsersController : ControllerBase
        {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
            {
            _userService = userService;
            }

        /// <summary>
        /// Rejestracja nowego użytkownika
        /// </summary>
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
            {
            try
                {
                await _userService.RegisterAsync(dto);
                return Ok(new { message = "Użytkownik został zarejestrowany." });
                }
            catch (InvalidOperationException ex)
                {
                return BadRequest(new { message = ex.Message });
                }
            }

        /// <summary>
        /// Logowanie użytkownika
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
            {
            var token = await _userService.LoginAsync(dto);

            if (token == null)
                return Unauthorized(new { message = "Nieprawidłowy e-mail lub hasło." });

            return Ok(new { token });
            }
        }
    }
