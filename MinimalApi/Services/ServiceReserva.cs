using MinimalApi.Model;
using MinimalApi.Repositories;

namespace MinimalApi.Services
{
    public class ServiceReserva : IServiceReserva
    {
        private readonly IRepositorioReserva _RepositorioReserva;
        private readonly IRepositorioVoo _RepositorioVoo;

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
            
            return "Bilhete gerado"; 
        }

        public async Task<IEnumerable<RelatorioVendas>> GetRelatorioVendasMensalAsync()
        {
            // Obter vendas do mês atual e do mês anterior
            var vendasDoMes = await _RepositorioReserva.GetVendasUltimoMesAsync();
            var vendasMesAnterior = await _RepositorioReserva.GetVendasMesAnteriorAsync();

            // Criar o relatório de vendas
            var relatorio = vendasDoMes
                .GroupBy(v => v.IdVoo)
                .Select(g => new RelatorioVendas
                {
                    VooId = g.Key,
                    TotalArrecadado = g.Sum(v => v.Voo.Preco),  // Total arrecadado para o voo
                    FormaPagamento = g.GroupBy(v => v.FormaPagamento)
                        .Select(fg => new FormaPagamentoRelatorio
                        {
                            Forma = fg.Key,
                            Total = fg.Sum(v => v.Voo.Preco)  // Total arrecadado por forma de pagamento
                        }),
                    ComparacaoComMesAnterior = vendasMesAnterior
                        .Where(vm => vm.IdVoo == g.Key)
                        .Sum(vm => vm.Voo.Preco)  // Comparação com o mês anterior
                });

            return relatorio;
        }

    }
}
