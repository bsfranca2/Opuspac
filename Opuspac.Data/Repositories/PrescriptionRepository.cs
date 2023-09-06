using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Opuspac.Core.Repositories;
using Opuspac.Data.Models;

namespace Opuspac.Data.Repositories;

public class PrescriptionRepository : Repository<Core.Entities.Prescription, Prescription, Guid>, IPrescriptionRepository
{
    public PrescriptionRepository(IServiceScopeFactory serviceScopeFactory, IMapper mapper)
        : base(serviceScopeFactory, mapper, (DatabaseContext context) => context.Prescriptions) { }
}
