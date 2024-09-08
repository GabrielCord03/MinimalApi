using MinimalApi.Model;

namespace MinimalApi.Services
{
    public interface IServiceReserva
    {
        Task<Reserva> GetReservaByIdAsync(int id);
        Task AddReservaAsync(Reserva reserva);
        Task UpdateReservaAsync(Reserva reserva);
        Task DeleteReservaAsync(int id);
    }

}
