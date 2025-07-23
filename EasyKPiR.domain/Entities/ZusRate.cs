using System;
using System.Collections.Generic;
using System.Text;

namespace EasyKPiR.Domain.Entities
    {
    public class ZusRate
        {
        public int Id { get; set; }
        public int Year { get; set; }
        public string RateName { get; set; } = default!;
        public decimal RateValue { get; set; }
        }
    }
