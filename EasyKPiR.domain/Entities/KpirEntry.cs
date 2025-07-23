using System;
using System.Collections.Generic;
using System.Text;

namespace EasyKPiR.Domain.Entities
    {
    public class KpirEntry
        {
        public int Id { get; set; }
        public int EntryNumber { get; set; }
        public DateTime EventDate { get; set; }
        public string DocumentNumber { get; set; } = default!;
        public string ContractorName { get; set; } = default!;
        public string ContractorAddress { get; set; } = default!;
        public string IncomeOrCostType { get; set; } = default!;
        public decimal IncomeSales { get; set; }
        public decimal IncomeOther { get; set; }
        public decimal IncomeTotal { get; set; }
        public decimal PurchaseGoods { get; set; }
        public decimal PurchaseSideCosts { get; set; }
        public decimal WagesGross { get; set; }
        public decimal OtherCosts { get; set; }
        public decimal CostsTotal { get; set; }
        public string? Notes { get; set; }
        public decimal ResearchDevelopmentCosts { get; set; }
        }
    }
