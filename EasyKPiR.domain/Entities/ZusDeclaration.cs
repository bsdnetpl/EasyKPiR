using System;
using System.Collections.Generic;
using System.Text;

namespace EasyKPiR.Domain.Entities
    {
    public class ZusDeclaration
        {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = default!;

        public int Year { get; set; }
        public int Month { get; set; }

        public decimal Pension { get; set; }
        public decimal Disability { get; set; }
        public decimal Accident { get; set; }
        public decimal Sickness { get; set; }
        public decimal LaborFund { get; set; }
        public decimal Health { get; set; }
        public decimal Total { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        }
    }
