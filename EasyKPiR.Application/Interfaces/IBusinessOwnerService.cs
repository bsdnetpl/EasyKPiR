using EasyKPiR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyKPiR.Application.Interfaces
    {
    public interface IBusinessOwnerService
        {
        Task<List<BusinessOwner>> GetAllAsync();
        Task<BusinessOwner?> GetByIdAsync(int id);
        Task<int> CreateAsync(BusinessOwner owner);
        Task<bool> UpdateAsync(int id, BusinessOwner updatedOwner);
        Task<bool> DeleteAsync(int id);
        Task<BusinessOwner?> GetCurrentAsync(); // jeśli ma być jeden "aktywny" właściciel
        }
    }
