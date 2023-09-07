using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Opuspac.Core.Repositories;
using Opuspac.Data.Models;

namespace Opuspac.Data.Repositories;

public class PrescriptionMedicineRepository : Repository<Core.Entities.PrescriptionMedicine, PrescriptionMedicine, Guid>, IPrescriptionMedicineRepository
{
    public PrescriptionMedicineRepository(IServiceScopeFactory serviceScopeFactory, IMapper mapper)
        : base(serviceScopeFactory, mapper, (DatabaseContext context) => context.PrescriptionMedicines) { }

    public async Task<List<Core.Entities.PrescriptionMedicine>> GetManyByPrescriptionIdAsync(Guid prescriptionId)
    {
        using var scope = ServiceScopeFactory.CreateScope();
        var dbContext = GetDatabaseContext(scope);
        var prescriptionMedicines = await dbContext.PrescriptionMedicines
            .Where(prescriptionMedicine => prescriptionMedicine.PrescriptionId == prescriptionId)
            .ToListAsync();
        return Mapper.Map<List<Core.Entities.PrescriptionMedicine>>(prescriptionMedicines);
    }
}
