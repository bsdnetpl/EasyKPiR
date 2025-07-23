using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EasyKPiR.Domain.Entities
    {

    public class MinimumWage
        {
        [Key]
        public int Id { get; set; }
        public int Year { get; set; }
        public decimal Minimum { get; set; }
        public decimal Average { get; set; }
        }
    }
