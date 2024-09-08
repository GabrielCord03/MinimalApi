using MinimalApi.Model;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MinimalApi.Data
{
    public class AirlineDbContext : DbContext
    {
        public DbSet<Passageiro> Passageiros { get; set; }
        public DbSet<Voo> Voos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        public AirlineDbContext(DbContextOptions<AirlineDbContext> options) : base(options)
        {
        }
    }
}
