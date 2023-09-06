using Microsoft.EntityFrameworkCore;
using Opuspac.Api.Hubs;
using Opuspac.Data;
using Opuspac.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.SetupEntityFramework();
builder.Services.AddEfRepositories();

builder.Services.AddControllers();
builder.Services.AddCors(p => p.AddPolicy("corspolicy", policyBuilder =>
{
    var origins = builder.Configuration.GetValue<string>("Origins");
    if (origins != null)
    {
        policyBuilder.WithOrigins(origins).AllowAnyMethod().AllowAnyHeader();
    }
}));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

var app = builder.Build();

// TODO: Deve ter algo melhor do que isso
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corspolicy");
app.MapControllers();

app.MapHub<PrinterHub>("/printer");

app.Run();
