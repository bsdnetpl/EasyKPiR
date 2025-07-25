using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyKPiR.Application.DTOs
    {
    public class InvoiceDto
        {
        public int Id { get; set; }
        public string Number { get; set; } = default!;
        public DateTime IssueDate { get; set; }
        public string SellerNIP { get; set; } = default!;
        public string BuyerNIP { get; set; } = default!;
        public decimal AmountNet { get; set; }
        public decimal AmountVat { get; set; }
        public decimal AmountGross { get; set; }
        public string Type { get; set; } = string.Empty;
        }
    }

