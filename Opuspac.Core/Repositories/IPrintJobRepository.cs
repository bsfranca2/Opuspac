using Opuspac.Core.Entities;
using Opuspac.Core.Enums;

namespace Opuspac.Core.Repositories;

public interface IPrintJobRepository : IRepository<PrintJob, Guid>
{
    public Task<int> GetJobsCountByStatusAsync(PrintJobStatus printJobStatus);
}