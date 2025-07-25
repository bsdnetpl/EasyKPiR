using AutoMapper;
using EasyKPiR.Application.Interfaces;
using EasyKPiR.Domain.Entities;
using EasyKPiR.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyKPiR.Infrastructure.Services
    {
    public class BusinessOwnerService : IBusinessOwnerService
        {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public BusinessOwnerService(ApplicationDbContext db, IMapper mapper)
            {
            _db = db;
            _mapper = mapper;
            }

        public async Task<List<BusinessOwner>> GetAllAsync()
            {
            return await _db.BusinessOwners.ToListAsync();
            }

        public async Task<BusinessOwner?> GetByIdAsync(int id)
            {
            return await _db.BusinessOwners.FindAsync(id);
            }

        public async Task<int> CreateAsync(BusinessOwner owner)
            {
            _db.BusinessOwners.Add(owner);
            await _db.SaveChangesAsync();
            return owner.Id;
            }

        public async Task<bool> UpdateAsync(int id, BusinessOwner updatedOwner)
            {
            var owner = await _db.BusinessOwners.FindAsync(id);
            if (owner == null)
                return false;

            _mapper.Map(updatedOwner, owner);

            await _db.SaveChangesAsync();
            return true;
            }


        public async Task<bool> DeleteAsync(int id)
            {
            var owner = await _db.BusinessOwners.FindAsync(id);
            if (owner == null)
                return false;

            _db.BusinessOwners.Remove(owner);
            await _db.SaveChangesAsync();
            return true;
            }

        public async Task<BusinessOwner?> GetCurrentAsync()
            {
            // Zakładamy, że masz tylko jednego właściciela w bazie:
            return await _db.BusinessOwners.FirstOrDefaultAsync();
            }
        }
    }
