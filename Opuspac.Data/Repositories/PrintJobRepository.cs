using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Opuspac.Core.Enums;
using Opuspac.Core.Repositories;
using Opuspac.Data.Models;

namespace Opuspac.Data.Repositories;

public class PrintJobRepository : Repository<Core.Entities.PrintJob, PrintJob, Guid>, IPrintJobRepository
{
    public PrintJobRepository(IServiceScopeFactory serviceScopeFactory, IMapper mapper)
        : base(serviceScopeFactory, mapper, (DatabaseContext context) => context.PrintJobs) { }

    public async Task<int> GetJobsCountByStatusAsync(PrintJobStatus printJobStatus)
    {
        using (var scope = ServiceScopeFactory.CreateScope())
        {
            var dbContext = GetDatabaseContext(scope);
            return await dbContext.PrintJobs.CountAsync(printJob => printJob.Status == printJobStatus);
        }
    }
}