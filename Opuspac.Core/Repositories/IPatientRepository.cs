﻿using Opuspac.Core.Entities;

namespace Opuspac.Core.Repositories;

public interface IPatientRepository : IRepository<Patient, Guid>
{
    Task<IEnumerable<Patient>> SearchAsync();
}