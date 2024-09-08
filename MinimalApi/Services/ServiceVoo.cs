using Microsoft.EntityFrameworkCore;
using MinimalApi.Data;
using MinimalApi.Model;

namespace MinimalApi.Services
{
    public class ServiceVoo : IServiceVoo
    {
        private readonly IServiceVoo _RepositorioVoo;

        public ServiceVoo(IServiceVoo RepositorioVoo)
        {
            _RepositorioVoo = RepositorioVoo;
        }

        public async Task<IEnumerable<Voo>> GetVoosAsync(string origin, string destination, DateTime departureDate, DateTime? returnDate)
        {
            return await _RepositorioVoo.GetVoosAsync(origin, destination, departureDate, returnDate);
        }

        public async Task<Voo> GetVooByIdAsync(int id)
        {
            return await _RepositorioVoo.GetVooByIdAsync(id);
        }

        public async Task AddVooAsync(Voo voo)
        {
            await _RepositorioVoo.AddVooAsync(voo);
        }

        public async Task UpdateVooAsync(Voo voo)
        {
            await _RepositorioVoo.UpdateVooAsync(voo);
        }

        public async Task DeleteVooAsync(int id)
        {
            await _RepositorioVoo.DeleteVooAsync(id);
        }
    }

}
