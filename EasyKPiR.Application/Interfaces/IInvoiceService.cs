using EasyKPiR.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyKPiR.Application.Interfaces
    {
    public interface IInvoiceService
        {
        Task<List<InvoiceDto>> GetAllAsync();
        Task<InvoiceDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(InvoiceDto dto);
        Task<bool> UpdateAsync(int id, InvoiceDto dto);
        Task<bool> DeleteAsync(int id);
        Task<List<InvoiceDto>> SearchAsync(string term); // Wyszukiwanie po NIP i nazwie
        }
    }
