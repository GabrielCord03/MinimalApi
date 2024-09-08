using Microsoft.EntityFrameworkCore;
using MinimalApi.Data;
using MinimalApi.Model;

namespace MinimalApi.Repositories
{
    public class ReservaRepository : IRepositorioReserva
    {
        private readonly AirlineDbContext _context;

        public ReservaRepository(AirlineDbContext context)
        {
            _context = context;
        }

        public async Task<Reserva> GetReservaByIdAsync(int id)
        {
            return await _context.Reservas.Include(r => r.Passageiros).Include(r => r.Voo).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddReservaAsync(Reserva Reserva)
        {
            _context.Reservas.Add(Reserva);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReservaAsync(Reserva Reserva)
        {
            _context.Reservas.Update(Reserva);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReservaAsync(int id)
        {
            var Reserva = await _context.Reservas.FindAsync(id);
            if (Reserva != null)
            {
                _context.Reservas.Remove(Reserva);
                await _context.SaveChangesAsync();
            }
        }
    }

}
