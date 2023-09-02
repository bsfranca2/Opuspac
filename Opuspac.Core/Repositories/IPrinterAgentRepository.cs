using Opuspac.Core.Entities;

namespace Opuspac.Core.Repositories;

public interface IPrinterAgentRepository : IRepository<PrinterAgent, Guid>
{
    Task<PrinterAgent> GetByIpAsync(string ip);
    Task<IEnumerable<PrinterAgent>> SearchAsync();
    Task<int> GetPrinterAgentsCountByIsConnected();
}