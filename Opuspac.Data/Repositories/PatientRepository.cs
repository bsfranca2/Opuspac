﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Opuspac.Core.Repositories;
using Opuspac.Data.Models;

namespace Opuspac.Data.Repositories;

public class PatientRepository : Repository<Core.Entities.Patient, Patient, Guid>, IPatientRepository
{
    public PatientRepository(IServiceScopeFactory serviceScopeFactory, IMapper mapper)
        : base(serviceScopeFactory, mapper, (DatabaseContext context) => context.Patients) { }

    public async Task<List<Core.Entities.Patient>> SearchAsync()
    {
        using var scope = ServiceScopeFactory.CreateScope();
        var dbContext = GetDatabaseContext(scope);
        var patients = await dbContext.Patients.ToListAsync();
        return Mapper.Map<List<Core.Entities.Patient>>(patients);
    }
}