﻿namespace CaseItau.API.ViewModels
{
    public class ParametroFundoViewModel
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public int CodigoTipo { get; set; }
        public decimal? Patrimonio { get; set; }
    }
}
