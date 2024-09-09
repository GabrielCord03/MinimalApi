using MinimalApi.Model;

namespace MinimalApi.Repositories
{
    public interface IRepositorioPassageiro
    {
        Task<Passageiro?> GetPassageiroByCpfAsync(string cpf);
        Task AddPassageiroAsync(Passageiro passageiro);
    }
}
