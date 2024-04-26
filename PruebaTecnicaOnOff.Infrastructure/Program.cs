using PruebaTecnicaOnOff.Infrastructure.Middleware;
using PruebaTecnicaOnOff.Repository.Context;
using PruebaTecnicaOnOff.Repository.Repository;
using PruebaTecnicaOnOff.Repository.Repository.IRepository;
using PruebaTecnicaOnOff.Service.Servicios;
using PruebaTecnicaOnOff.Service.Servicios.IServicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServer<PruebaTecnicaOnOffContext>(builder.Configuration.GetConnectionString("connectionStringEF"));
builder.Services.AddScoped<IPremioSorteoRepository, PremioSorteoRepository>();
builder.Services.AddScoped<IPremioSorteoService, PremioSorteoService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseMiddleware<ApiKeyMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
