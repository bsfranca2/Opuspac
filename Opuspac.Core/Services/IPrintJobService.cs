using Opuspac.Core.Entities;
using Opuspac.Core.Models;

namespace Opuspac.Core.Services;

public interface IPrintJobService
{
    public Task<PrintJob> CreateAsync(Guid prescriptionId, string ipAddress);
    public Task<PrintJobMessage> GetPrintJobMessageAsync(Guid printJobId);
}
