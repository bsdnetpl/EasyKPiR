
using System.Text;
using EasyKPiR.Application.DTOs;
using EasyKPiR.Application.Interfaces;
using System.Security.Cryptography;
using EasyKPiR.Infrastructure.Auth;
using EasyKPiR.Domain.Entities;
using EasyKPiR.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;



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
            var hash = HashPassword(dto.Password);

            var user = await _db.Users.FirstOrDefaultAsync(u =>
                u.Email == dto.Email && u.PasswordHash == hash);

            if (user == null)
                return null;

            return _jwt.GenerateToken(user);
            }

        private static string HashPassword(string password)
            {
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = SHA256.HashData(bytes);
            return Convert.ToBase64String(hash);
            }
        }
    }
