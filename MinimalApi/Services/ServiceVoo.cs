using MinimalApi.Model;
using MinimalApi.Repositories;

namespace MinimalApi.Services
{
    public class ServiceVoo : IServiceVoo
    {
        private readonly IRepositorioVoo _repositorioVoo;

        public ServiceVoo(IRepositorioVoo repositorioVoo)
        {
            _repositorioVoo = repositorioVoo;
        }

        public async Task<IEnumerable<Voo>> GetVoosAsync(string origem, string destino, DateTime dataEmbarque, DateTime? dataRetorno)
        {
            return await _repositorioVoo.GetVoosAsync(origem, destino, dataEmbarque, dataRetorno);
        }

        public async Task<Voo> GetVooByIdAsync(int id)
        {
            return await _repositorioVoo.GetVooByIdAsync(id);
        }

        public async Task AddVooAsync(Voo voo)
        {
            await _repositorioVoo.AddVooAsync(voo);
        }

        public async Task UpdateVooAsync(Voo voo)
        {
            await _repositorioVoo.UpdateVooAsync(voo);
        }

        public async Task DeleteVooAsync(int id)
        {
            await _repositorioVoo.DeleteVooAsync(id);
        }

        public async Task<IEnumerable<RelatorioOcupacao>> GetRelatorioOcupacaoSemanalAsync()
        {
            var voos = await _repositorioVoo.GetVoosUltimaSemanaAsync();
            return voos.Select(v => new RelatorioOcupacao
            {
                VooId = v.Id,
                Origem = v.Origem,
                Destino = v.Destino,
                DataEmbarque = v.DataEmbarque,
                PercentualOcupacao = ((v.AssentosTotais - v.AssentosDisponiveis) / (double)v.AssentosTotais) * 100
            });
        }

    }
}
