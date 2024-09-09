using MinimalApi.Model;

namespace MinimalApi.Services
{
    public interface IServicePassageiro
    {
        Task<Passageiro?> GetPassageiroByCpfAsync(string cpf);
        Task AddPassageiroAsync(Passageiro passageiro);
    }
}
