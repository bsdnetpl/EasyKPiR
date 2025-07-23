using System;
using System.Collections.Generic;
using System.Text;

namespace EasyKPiR.Domain.Entities
    {
    public class ZusCalculationResultDto
        {
        public decimal Pension { get; set; }              // emerytalne
        public decimal Disability { get; set; }           // rentowe
        public decimal Accident { get; set; }             // wypadkowe
        public decimal Sickness { get; set; }            // chorobowe (jeśli wybrane)
        public decimal Health { get; set; }               // zdrowotne
        public decimal LaborFund { get; set; }           // FP+FS
        public decimal Total { get; set; }
        }
    }
