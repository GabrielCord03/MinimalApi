using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MinimalApi.Data;
using MinimalApi.Repositories;
using MinimalApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do DbContext
builder.Services.AddDbContext<AirlineDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona servi�os ao cont�iner
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Airline Reservation API", Version = "v1" });
});

// Registre os reposit�rios
builder.Services.AddScoped<IRepositorioPassageiro, PassageiroRepositorio>();
builder.Services.AddScoped<IRepositorioReserva, ReservaRepository>();
builder.Services.AddScoped<IRepositorioVoo, VooRepository>();

// Registre os servi�os
builder.Services.AddScoped<IServicePassageiro, ServicePassageiro>();
builder.Services.AddScoped<IServiceReserva, ServiceReserva>();
builder.Services.AddScoped<IServiceVoo, ServiceVoo>();

var app = builder.Build();

// Configura��o do pipeline de solicita��o
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Airline Reservation API V1");
    });
}

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
