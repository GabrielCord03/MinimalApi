namespace MinimalApi.Model
{
    public class Voo
    {
        public int Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public DateTime DataEmbarque { get; set; }
        public DateTime? DataRetorno { get; set; }
        public string Airline { get; set; }
        public decimal Preco { get; set; }
        public int AssentosDisponiveis { get; set; }
        public int AssentosTotais { get; set; }
    }
}
