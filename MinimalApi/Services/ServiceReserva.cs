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
        public async Task CheckInAsync(int id)
        {
            var reserva = await _RepositorioReserva.GetReservaByIdAsync(id);
            if (reserva == null || reserva.CheckedIn)
            {
                throw new InvalidOperationException("Reserva não encontrada ou já realizada.");
            }

            // Verifique se o voo permite check-in
            var voo = await _RepositorioVoo.GetVooByIdAsync(reserva.IdVoo);
            if (voo == null || voo.DataEmbarque > DateTime.UtcNow.AddHours(1))
            {
                throw new InvalidOperationException("Check-in não permitido.");
            }

            reserva.CheckedIn = true;
            await _RepositorioReserva.UpdateReservaAsync(reserva);

            var bilhete = await GerarBilheteEletronicoAsync(id);
            reserva.BilheteEletronico = bilhete;
            await _RepositorioReserva.UpdateReservaAsync(reserva);
        }

        public async Task<string> GerarBilheteEletronicoAsync(int id)
        {
            // Lógica para gerar bilhete eletrônico
            return "Bilhete gerado"; // Retornar bilhete em formato de string ou arquivo
        }
    }
}
