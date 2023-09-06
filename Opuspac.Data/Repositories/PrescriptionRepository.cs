using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Opuspac.Core.Models;
using Opuspac.Core.Repositories;
using Opuspac.Data.Models;

namespace Opuspac.Data.Repositories;

public class PrescriptionRepository : Repository<Core.Entities.Prescription, Prescription, Guid>, IPrescriptionRepository
{
    public PrescriptionRepository(IServiceScopeFactory serviceScopeFactory, IMapper mapper)
        : base(serviceScopeFactory, mapper, (DatabaseContext context) => context.Prescriptions) { }

    public async Task<List<PrescriptionDetails>> SearchAsync()
    {
        using (var scope = ServiceScopeFactory.CreateScope())
        {
            var dbContext = GetDatabaseContext(scope);
            var query = from prescription in dbContext.Prescriptions
             join patient in dbContext.Patients on prescription.PatientId equals patient.Id
             select new PrescriptionDetails
             {
                 Id = prescription.Id,
                 Code = prescription.Code,
                 AttendantId = prescription.AttendantId,
                 Time = prescription.Time,
                 PatientId = prescription.PatientId,
                 Patient = patient
             };
            return await query.ToListAsync();
        }
    }
}
