using EasyKPiR.Application.DTOs;
using EasyKPiR.Application.Interfaces;
using EasyKPiR.Domain.Entities;
using EasyKPiR.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EasyKPiR.Infrastructure.Services;

public class ZusService : IZusService
    {
    private readonly ApplicationDbContext _db;

    public ZusService(ApplicationDbContext db)
        {
        _db = db;
        }

    public ZusCalculationResultDto Calculate(ZusCalculationRequestDto dto)
        {
        // pobieramy wartości minimalne/przeciętne dla danego roku
        var wages = _db.MinimumWages
            .AsNoTracking()
            .FirstOrDefault(w => w.Year == dto.Year);

        if (wages == null)
            throw new InvalidOperationException($"Brak danych o wynagrodzeniu minimalnym/przeciętnym dla roku {dto.Year}.");

        // pobieramy stawki zus dla danego roku
        var rates = _db.ZusRates
            .AsNoTracking()
            .Where(r => r.Year == dto.Year)
            .ToDictionary(r => r.RateName, r => r.RateValue);

        if (!rates.Any())
            throw new InvalidOperationException($"Brak stawek ZUS dla roku {dto.Year}.");

        // wyliczenie podstawy
        decimal baseAmount = dto.Preferential
            ? wages.Minimum * 0.3m
            : wages.Average * 0.6m;

        if (dto.LumpSum)
            baseAmount = wages.Minimum * 0.75m;

        // składki społeczne
        var pension = Math.Round(baseAmount * rates["Pension"], 2);
        var disability = Math.Round(baseAmount * rates["Disability"], 2);
        var accident = Math.Round(baseAmount * rates["Accident"], 2);
        var sickness = dto.IncludeSickness
            ? Math.Round(baseAmount * rates["Sickness"], 2)
            : 0;
        var laborFund = Math.Round(baseAmount * rates["LaborFund"], 2);

        // zdrowotna
        decimal health = Math.Round(baseAmount * rates["Health"], 2);

        var nadwyzka = dto.Income - (1.5m * wages.Average);
        if (nadwyzka > 0)
            health += Math.Round(nadwyzka * rates["HealthOverThreshold"], 2);

        var total = pension + disability + accident + sickness + laborFund + health;

        return new ZusCalculationResultDto
            {
            Pension = pension,
            Disability = disability,
            Accident = accident,
            Sickness = sickness,
            LaborFund = laborFund,
            Health = health,
            Total = total
            };
        }
    }
