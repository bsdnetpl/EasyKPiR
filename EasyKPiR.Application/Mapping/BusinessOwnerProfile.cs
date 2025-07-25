using AutoMapper;
using EasyKPiR.Application.DTOs;
using EasyKPiR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyKPiR.Application.Mapping
    {
    public class BusinessOwnerProfile : Profile
        {
        public BusinessOwnerProfile()
            {
            // Mapowanie DTO ↔ Entity
            CreateMap<BusinessOwner, BusinessOwnerDto>().ReverseMap();

            // Mapowanie samego siebie (np. dla aktualizacji przez AutoMapper.Map)
            CreateMap<BusinessOwner, BusinessOwner>();
            }
        }
    }
