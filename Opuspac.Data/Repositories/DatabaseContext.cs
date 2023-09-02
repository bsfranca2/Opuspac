using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Opuspac.Data.Models;

namespace Opuspac.Data.Repositories;

public class DatabaseContext : DbContext
{

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    { }

    public DbSet<PrinterAgent> PrinterAgents { get; set; }
    public DbSet<PrintJob> PrintJobs { get; set; }
    public DbSet<Patient> Patients { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Scans and loads all configurations implementing the `IEntityTypeConfiguration` from the
        //  `Infrastructure.EntityFramework` Module. Note to get the assembly we can use a random class
        //   from this module.
        builder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);

        // Going forward use `IEntityTypeConfiguration` in the Configurations folder for managing
        // Entity Framework code first database configurations.
        var ePrinterAgent = builder.Entity<PrinterAgent>();
        var ePrintJob = builder.Entity<PrintJob>();
        var ePatient = builder.Entity<Patient>();

        ePrinterAgent.Property(c => c.Id).ValueGeneratedNever();
        ePrintJob.Property(c => c.Id).ValueGeneratedNever();
        ePatient.Property(c => c.Id).ValueGeneratedNever();

        ePrinterAgent.ToTable(nameof(PrinterAgent));
        ePrintJob.ToTable(nameof(PrintJob));
        ePatient.ToTable(nameof(Patient));

        ConfigureDateTimeUtcQueries(builder);
    }

    // Make sure this is called after configuring all the entities as it iterates through all setup entities.
    private void ConfigureDateTimeUtcQueries(ModelBuilder builder)
    {
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            if (entityType.IsKeyless)
            {
                continue;
            }
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                {
                    property.SetValueConverter(
                        new ValueConverter<DateTime, DateTime>(
                            v => v,
                            v => new DateTime(v.Ticks, DateTimeKind.Utc)));
                }
            }
        }
    }
}