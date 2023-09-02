using Microsoft.EntityFrameworkCore;
using Opuspac.Api.Hubs;
using Opuspac.Data;
using Opuspac.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.SetupEntityFramework();
builder.Services.AddEfRepositories();

builder.Services.AddControllers();
builder.Services.AddCors(p => p.AddPolicy("corspolicy", policyBuilder =>
{
    // TODO: Noa deixar valor fixo
    policyBuilder.WithOrigins("http://localhost:5173").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corspolicy");
app.MapControllers();

app.MapHub<PrinterHub>("/printer");

app.Run();
