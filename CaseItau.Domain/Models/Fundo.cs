namespace CaseItau.Domain.Models
{
    public class Fundo
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public int Codigo_Tipo { get; set; }
        public string Nome_Tipo { get; set; }
        public decimal? Patrimonio { get; set; }
    }
}
