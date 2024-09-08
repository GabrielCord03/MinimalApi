namespace MinimalApi.Model
{
    public class Passageiro
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string TelefoneCel { get; set;} = string.Empty;
        public string TelefoneFix { get; set; } = string.Empty;
    }
}
