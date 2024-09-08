using MinimalApi.Model;

namespace MinimalApi.Repositories
{
    public interface IRepositorioReserva
    {
        Task<Reserva> GetReservaByIdAsync(int id);
        Task AddReservaAsync(Reserva reservas);
        Task UpdateReservaAsync(Reserva reservas);
        Task DeleteReservaAsync(int id);
    }
}
