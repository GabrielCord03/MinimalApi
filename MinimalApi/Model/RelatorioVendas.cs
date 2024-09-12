namespace MinimalApi.Model
{
    public class RelatorioVendas
    {
        public int VooId { get; set; }
        public decimal TotalArrecadado { get; set; }
        public IEnumerable<FormaPagamentoRelatorio> FormaPagamento { get; set; }
        public decimal ComparacaoComMesAnterior { get; set; }
    }

    public class FormaPagamentoRelatorio
    {
        public string Forma { get; set; }
        public decimal Total { get; set; }
    }
}
