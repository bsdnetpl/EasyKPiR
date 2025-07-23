using System.Text;
using EasyKPiR.Application.DTOs;
using EasyKPiR.Application.Interfaces;
using EasyKPiR.Infrastructure.Auth;
using EasyKPiR.Domain.Entities;
using EasyKPiR.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace EasyKPiR.Infrastructure.Services
    {
    public class UserService : IUserService
        {
        private readonly ApplicationDbContext _db;
        private readonly IJwtTokenService _jwt;

        public UserService(ApplicationDbContext db, IJwtTokenService jwt)
            {
            _db = db;
            _jwt = jwt;
            }

        public async Task RegisterAsync(RegisterDto dto)
            {
            if (await _db.Users.AnyAsync(u => u.Email == dto.Email))
                throw new InvalidOperationException("Użytkownik z tym e-mailem już istnieje.");

            var hash = HashPassword(dto.Password);

            var user = new User
                {
                Email = dto.Email,
                PasswordHash = hash,
                Role = "User"
                };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            }

        public async Task<string?> LoginAsync(LoginDto dto)
            {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null)
                return null;

            if (!VerifyPassword(dto.Password, user.PasswordHash))
                return null;

            return _jwt.GenerateToken(user);
            }

        private static string HashPassword(string password)
            {
            return BCrypt.Net.BCrypt.HashPassword(password);
            }

        private static bool VerifyPassword(string password, string hashedPassword)
            {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            }
        }
    }
