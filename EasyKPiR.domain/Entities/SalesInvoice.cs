using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace EasyKPiR.Domain.Entities
    {
    public class SalesInvoice
        {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; } = default!;
        public DateTime Date { get; set; }
        public decimal NetAmount { get; set; }
        public decimal VATAmount { get; set; }
        public decimal GrossAmount { get; set; }

        public int ContractorId { get; set; }
        public Contractor Contractor { get; set; } = default!;

        public int UserId { get; set; }
        public User User { get; set; } = default!;
        }
    }
