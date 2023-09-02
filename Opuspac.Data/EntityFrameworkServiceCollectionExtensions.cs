using Microsoft.Extensions.DependencyInjection;
using Opuspac.Core.Repositories;
using Opuspac.Data.Repositories;
    
namespace Opuspac.Data;

public static class EntityFrameworkServiceCollectionExtensions
{
    public static void SetupEntityFramework(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(PatientRepository));
    }
    
    public static void AddEfRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IPrinterAgentRepository, PrinterAgentRepository>();
        services.AddSingleton<IPrintJobRepository, PrintJobRepository>();
        services.AddSingleton<IPatientRepository, PatientRepository>();
    }
}