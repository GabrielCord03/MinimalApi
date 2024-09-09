namespace MinimalApi.Model
{
    public class Reserva
    {
        public int Id { get; set; }
        public int IdPassageiro { get; set; }
        public int IdVoo { get; set; }
        public DateTime DataReserva { get; set; }
        public int NumAssento { get; set; }
        public Passageiro Passageiros { get; set; }
        public Voo Voo { get; set; }
        public bool CheckedIn { get; set; }
        public string? BilheteEletronico { get; set; }
    }
}
