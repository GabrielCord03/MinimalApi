using Microsoft.EntityFrameworkCore;
using MinimalApi.Data;
using MinimalApi.Model;

namespace MinimalApi.Repositories
{
    public class VooRepository : IRepositorioVoo
    {
        private readonly AirlineDbContext _context;

        public VooRepository(AirlineDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Voo>> GetVoosAsync(string Origem, string Destino, DateTime DataEmbarque, DateTime? DataRetorno)
        {
            return await _context.Voos
                .Where(f => f.Origem == Origem && f.Destino == Destino && f.DataEmbarque >= DataEmbarque && (!DataRetorno.HasValue || f.DataRetorno <= DataRetorno))
                .ToListAsync();
        }

        public async Task<Voo> GetVooByIdAsync(int id)
        {
            return await _context.Voos.FindAsync(id);
        }

        public async Task AddVooAsync(Voo Voo)
        {
            _context.Voos.Add(Voo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVooAsync(Voo Voo)
        {
            _context.Voos.Update(Voo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVooAsync(int id)
        {
            var Voo = await _context.Voos.FindAsync(id);
            if (Voo != null)
            {
                _context.Voos.Remove(Voo);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Voo>> GetVoosUltimaSemanaAsync()
        {
            var umaSemanaAtras = DateTime.UtcNow.AddDays(-7);
            return await _context.Voos
                .Where(v => v.DataEmbarque >= umaSemanaAtras)
                .ToListAsync();
        }
    }
}
