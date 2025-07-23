using EasyKPiR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyKPiR.Application.Interfaces
    {
    public interface IJwtTokenService
        {
        string GenerateToken(User user);
        }
    }
