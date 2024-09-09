using MinimalApi.Data;
using MinimalApi.Model;
using Microsoft.EntityFrameworkCore;

namespace MinimalApi.Repositories
{
    public class PassageiroRepositorio : IRepositorioPassageiro
    {
        private readonly AirlineDbContext _context;

        public PassageiroRepositorio(AirlineDbContext context)
        {
            _context = context;
        }

        public async Task<Passageiro?> GetPassageiroByCpfAsync(string cpf)
        {
            return await _context.Passageiros.FirstOrDefaultAsync(p => p.CPF == cpf);
        }

        public async Task AddPassageiroAsync(Passageiro passageiro)
        {
            _context.Passageiros.Add(passageiro);
            await _context.SaveChangesAsync();
        }
    }
}
