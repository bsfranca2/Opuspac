using Opuspac.Core.Entities;
using Opuspac.Core.Models;

namespace Opuspac.Core.Repositories;

public interface IPrescriptionRepository : IRepository<Prescription, Guid>
{
    Task<List<PrescriptionDetails>> SearchAsync();
}