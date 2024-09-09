using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MinimalApi.Data;
using MinimalApi.Repositories;
using MinimalApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuração do DbContext
builder.Services.AddDbContext<AirlineDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona serviços ao contêiner
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Airline Reservation API", Version = "v1" });
});

// Registre os repositórios
builder.Services.AddScoped<IRepositorioPassageiro, PassageiroRepositorio>();
builder.Services.AddScoped<IRepositorioReserva, ReservaRepository>();
builder.Services.AddScoped<IRepositorioVoo, VooRepository>();

// Registre os serviços
builder.Services.AddScoped<IServicePassageiro, ServicePassageiro>();
builder.Services.AddScoped<IServiceReserva, ServiceReserva>();
builder.Services.AddScoped<IServiceVoo, ServiceVoo>();

var app = builder.Build();

// Configuração do pipeline de solicitação
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
