using EasyKPiR.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyKPiR.Application.Interfaces
    {
    public interface IUserService
        {
        Task RegisterAsync(RegisterDto dto);
        Task<string?> LoginAsync(LoginDto dto);
        }
    }
