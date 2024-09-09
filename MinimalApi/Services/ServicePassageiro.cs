using MinimalApi.Model;
using MinimalApi.Repositories;

namespace MinimalApi.Services
{
    public class ServicePassageiro : IServicePassageiro
    {
        private readonly IRepositorioPassageiro _repositorioPassageiro;

        public ServicePassageiro(IRepositorioPassageiro repositorioPassageiro)
        {
            _repositorioPassageiro = repositorioPassageiro;
        }

        public async Task<Passageiro?> GetPassageiroByCpfAsync(string cpf)
        {
            return await _repositorioPassageiro.GetPassageiroByCpfAsync(cpf);
        }

        public async Task AddPassageiroAsync(Passageiro passageiro)
        {
            await _repositorioPassageiro.AddPassageiroAsync(passageiro);
        }
    }
}
