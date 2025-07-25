using AutoMapper;
using EasyKPiR.Application.DTOs;
using EasyKPiR.Application.Interfaces;
using EasyKPiR.Domain.Entities;
using EasyKPiR.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EasyKPiR.Infrastructure.Services
    {
    public class InvoiceService : IInvoiceService
        {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IBusinessOwnerService _ownerService;

        public InvoiceService(ApplicationDbContext db, IMapper mapper, IBusinessOwnerService ownerService)
            {
            _db = db;
            _mapper = mapper;
            _ownerService = ownerService;
            }

        public async Task<List<InvoiceDto>> GetAllAsync()
            {
            var owner = await _ownerService.GetCurrentAsync();
            var invoices = await _db.Invoices.ToListAsync();

            return invoices.Select(i =>
            {
                var dto = _mapper.Map<InvoiceDto>(i);
                dto.Type = i.SellerNIP == owner.NIP ? "Przychód" :
                           i.BuyerNIP == owner.NIP ? "Koszt" :
                           "Inny";
                return dto;
            }).ToList();
            }

        public async Task<InvoiceDto?> GetByIdAsync(int id)
            {
            var invoice = await _db.Invoices.FirstOrDefaultAsync(i => i.Id == id);
            if (invoice == null)
                return null;

            var dto = _mapper.Map<InvoiceDto>(invoice);
            var owner = await _ownerService.GetCurrentAsync();

            dto.Type = invoice.SellerNIP == owner.NIP ? "Przychód" :
                       invoice.BuyerNIP == owner.NIP ? "Koszt" :
                       "Inny";
            return dto;
            }

        public async Task<int> CreateAsync(InvoiceDto dto)
            {
            var invoice = _mapper.Map<Invoice>(dto);
            _db.Invoices.Add(invoice);
            await _db.SaveChangesAsync();
            return invoice.Id;
            }

        public async Task<bool> UpdateAsync(int id, InvoiceDto dto)
            {
            var invoice = await _db.Invoices.FindAsync(id);
            if (invoice == null)
                return false;

            _mapper.Map(dto, invoice);
            await _db.SaveChangesAsync();
            return true;
            }

        public async Task<bool> DeleteAsync(int id)
            {
            var invoice = await _db.Invoices.FindAsync(id);
            if (invoice == null)
                return false;

            _db.Invoices.Remove(invoice);
            await _db.SaveChangesAsync();
            return true;
            }

        public async Task<List<InvoiceDto>> SearchAsync(string term)
            {
            term = term.ToLower();
            var owner = await _ownerService.GetCurrentAsync();

            var invoices = await _db.Invoices
                .Where(i =>
                    i.SellerNIP.ToLower().Contains(term) ||
                    i.BuyerNIP.ToLower().Contains(term)
                )
                .ToListAsync();

            return invoices.Select(i =>
            {
                var dto = _mapper.Map<InvoiceDto>(i);
                dto.Type = i.SellerNIP == owner.NIP ? "Przychód" :
                           i.BuyerNIP == owner.NIP ? "Koszt" :
                           "Inny";
                return dto;
            }).ToList();
            }
        }
    }
