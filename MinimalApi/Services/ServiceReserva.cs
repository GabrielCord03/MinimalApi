using MinimalApi.Model;
using MinimalApi.Repositories;

namespace MinimalApi.Services
{
    public class ServiceReserva : IServiceReserva
    {
        private readonly IRepositorioReserva _RepositorioReserva;

        public ServiceReserva(IRepositorioReserva ReservaRepository)
        {
            _RepositorioReserva = ReservaRepository;
        }

        public async Task<Reserva> GetReservaByIdAsync(int id)
        {
            return await _RepositorioReserva.GetReservaByIdAsync(id);
        }

        public async Task AddReservaAsync(Reserva Reserva)
        {
            await _RepositorioReserva.AddReservaAsync(Reserva);
        }

        public async Task UpdateReservaAsync(Reserva Reserva)
        {
            await _RepositorioReserva.UpdateReservaAsync(Reserva);
        }

        public async Task DeleteReservaAsync(int id)
        {
            await _RepositorioReserva.DeleteReservaAsync(id);
        }
    }
}
