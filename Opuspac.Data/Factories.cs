using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Opuspac.Data.Repositories;

namespace Opuspac.Data;

public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        var services = new ServiceCollection();
        var serviceProvider = services.BuildServiceProvider();
        
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
        optionsBuilder
            .UseSqlite("DataSource=../app.db")
            .UseApplicationServiceProvider(serviceProvider);
        return new DatabaseContext(optionsBuilder.Options);
    }
}