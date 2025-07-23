using System;
using System.Collections.Generic;
using System.Text;

namespace EasyKPiR.Domain.Entities
    {
    public class FixedAsset
        {
        public int Id { get; set; }
        public string AssetName { get; set; } = default!;
        public DateTime PurchaseDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal AmortizationRate { get; set; }
        public string AmortizationMethod { get; set; } = default!;
        public decimal InitialValue { get; set; }
        public decimal CurrentValue { get; set; }
        public string? Notes { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = default!;
        }
    }
