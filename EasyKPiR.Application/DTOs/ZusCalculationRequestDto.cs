using System;
using System.Collections.Generic;
using System.Text;

namespace EasyKPiR.Application.DTOs
    {
    public class ZusCalculationRequestDto
        {
        public int Year { get; set; }
        public decimal MinimumWage { get; set; }    // np. 4666
        public decimal AverageWage { get; set; }    // przeciętne dla roku
        public bool Preferential { get; set; }      // true = 30%, false = 60%
        public bool IncludeSickness { get; set; }   // dobrowolne chorobowe
        public bool LumpSum { get; set; }           // ryczałt 75% minimalnej
        public decimal Income { get; set; }         // dochód do zdrowotnej
        }
    }
