using System.ComponentModel.DataAnnotations;

namespace CaseItau.API.ViewModels
{
    public class ParametroPatrimonioFundoViewModel
    {
        public string Codigo { get; set; }
        public decimal Patrimonio { get; set; }
    }
}
