using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Opuspac.Core.Repositories;
using Opuspac.Data.Models;

namespace Opuspac.Data.Repositories;

public class PrinterAgentRepository : Repository<Core.Entities.PrinterAgent, PrinterAgent, Guid>, IPrinterAgentRepository
{
    public PrinterAgentRepository(IServiceScopeFactory serviceScopeFactory, IMapper mapper)
        : base(serviceScopeFactory, mapper, (DatabaseContext context) => context.PrinterAgents) { }

    public async Task<Core.Entities.PrinterAgent> GetByIpAsync(string ip)
    {
        using (var scope = ServiceScopeFactory.CreateScope())
        {
            var dbContext = GetDatabaseContext(scope);
            var entity = await GetDbSet(dbContext).FirstOrDefaultAsync(e => e.Ip == ip);
            return Mapper.Map<Core.Entities.PrinterAgent>(entity);
        }
    }

    public async Task<IEnumerable<Core.Entities.PrinterAgent>> SearchAsync()
    {
        using (var scope = ServiceScopeFactory.CreateScope())
        {
            var dbContext = GetDatabaseContext(scope);
            var printerAgents = await dbContext.PrinterAgents.ToListAsync();
            return Mapper.Map<List<Core.Entities.PrinterAgent>>(printerAgents);
        }
    }

    public async Task<int> GetPrinterAgentsCountByIsConnected()
    {
        using (var scope = ServiceScopeFactory.CreateScope())
        {
            var dbContext = GetDatabaseContext(scope);
            return await dbContext.PrinterAgents.CountAsync(printerAgent => printerAgent.IsConnected == true);
        }
    }
}