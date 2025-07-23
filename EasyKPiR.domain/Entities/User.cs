﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EasyKPiR.Domain.Entities
    {
    public class User
        {
        public int Id { get; set; }

        public string Email { get; set; } = default!;

        public string PasswordHash { get; set; } = default!;

        public string Role { get; set; } = "User";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        }
    }
