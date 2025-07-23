using EasyKPiR.Application.DTOs;
using EasyKPiR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyKPiR.Application.Interfaces
    {
    public interface IZusService
        {
        ZusCalculationResultDto Calculate(ZusCalculationRequestDto dto);
        }
    }
