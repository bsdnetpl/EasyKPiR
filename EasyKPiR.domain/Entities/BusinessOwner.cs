using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyKPiR.Domain.Entities
    {
    public class BusinessOwner
        {
        public int Id { get; set; }

        // Dane firmy/osoby
        public string FullName { get; set; } = default!; // Imię i nazwisko lub nazwa firmy
        public string NIP { get; set; } = default!;
        public string REGON { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        // Informacje rozliczeniowe
        public string TaxOffice { get; set; } = string.Empty; // np. "US Częstochowa"
        public string BankAccount { get; set; } = string.Empty;
        public string AccountingSystem { get; set; } = string.Empty; // np. "KPiR", "ryczałt", itd.

        // Docelowo do wyliczeń podatków:
        public double VatRate { get; set; } // np. 0.23
        public double IncomeTaxRate { get; set; } // np. 0.19
        public double ZUSAmount { get; set; } // aktualna składka ZUS miesięczna
        }
    }
