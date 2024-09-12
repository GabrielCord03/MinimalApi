namespace MinimalApi.Model
{
    public class RelatorioOcupacao
    {
        public int VooId { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public DateTime DataEmbarque { get; set; }
        public double PercentualOcupacao { get; set; }
    }

}
