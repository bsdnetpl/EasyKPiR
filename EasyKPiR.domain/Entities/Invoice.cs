using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyKPiR.Domain.Entities
    {
    public class Invoice
        {
        public int Id { get; set; }
        public string Number { get; set; } = default!;
        public DateTime Date { get; set; }

        public string SellerName { get; set; } = default!;
        public string SellerNIP { get; set; } = default!;

        public string BuyerName { get; set; } = default!;
        public string BuyerNIP { get; set; } = default!;

        public decimal AmountNet { get; set; }
        public decimal AmountVat { get; set; }

        public decimal AmountGross => AmountNet + AmountVat;
        }
    }
