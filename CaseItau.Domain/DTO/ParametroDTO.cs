using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseItau.Domain.DTO
{
    public class ParametroIdFundoDTO
    {
        public string Codigo { get; set; }
    }

    public class ParametroPatrimonioFundoDTO
    {
        public string Codigo { get; set; }
        public decimal Patrimonio { get; set; }
    }

    public class ParametroFundoDTO
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public int CodigoTipo { get; set; }        
        public decimal? Patrimonio { get; set; }
    }
}
