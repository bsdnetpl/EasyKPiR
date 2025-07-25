using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyKPiR.Application.DTOs
    {
    public class BusinessOwnerDto
        {
        public int Id { get; set; }
        public string FullName { get; set; } = default!;
        public string NIP { get; set; } = default!;
        public string REGON { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public string TaxOffice { get; set; } = string.Empty;
        public string BankAccount { get; set; } = string.Empty;
        public string AccountingSystem { get; set; } = string.Empty;

        public double VatRate { get; set; }
        public double IncomeTaxRate { get; set; }
        public double ZUSAmount { get; set; }
        }
    }
