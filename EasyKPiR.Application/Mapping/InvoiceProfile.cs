using AutoMapper;
using EasyKPiR.Application.DTOs;
using EasyKPiR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyKPiR.Application.Mapping
    {
    public class InvoiceProfile : Profile
        {
        public InvoiceProfile()
            {
            CreateMap<Invoice, InvoiceDto>()
                .ForMember(dest => dest.AmountGross, opt => opt.MapFrom(src => src.AmountNet + src.AmountVat));

            CreateMap<InvoiceDto, Invoice>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // zwykle ignoruje się Id przy tworzeniu
                .ForMember(dest => dest.AmountGross, opt => opt.MapFrom(src => src.AmountNet + src.AmountVat));
            }
        }
    }
