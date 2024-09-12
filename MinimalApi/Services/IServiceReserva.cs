using MinimalApi.Model;

namespace MinimalApi.Services
{
    public interface IServiceReserva
    {
        Task<Reserva> GetReservaByIdAsync(int id);
        Task AddReservaAsync(Reserva reserva);
        Task UpdateReservaAsync(Reserva reserva);
        Task DeleteReservaAsync(int id);
        Task CheckInAsync(int id);
        Task<string> GerarBilheteEletronicoAsync(int id);
        Task<IEnumerable<RelatorioVendas>> GetRelatorioVendasMensalAsync();
    }

}
