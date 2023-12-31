﻿using Opuspac.Core.Entities;

namespace Opuspac.Core.Repositories;

public interface IPrescriptionMedicineRepository : IRepository<PrescriptionMedicine, Guid>
{
    Task<List<PrescriptionMedicine>> GetManyByPrescriptionIdAsync(Guid prescriptionId);
}