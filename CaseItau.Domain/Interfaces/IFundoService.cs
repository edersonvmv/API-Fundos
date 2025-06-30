using CaseItau.Domain.DTO;
using CaseItau.Domain.Models;

namespace CaseItau.Domain.Interfaces
{
    public interface IFundoService
    {
        Task<List<Fundo>> GetFundos();
        Task<Fundo?> GetFundo(ParametroIdFundoDTO parametro);
        Task<Fundo> PutPatrimonioFundo(ParametroPatrimonioFundoDTO parametro);
        Task<Fundo> PutFundo(ParametroFundoDTO parametro);
        Task<Fundo> PostFundo(ParametroFundoDTO parametro);
        Task<bool> DeleteFundo(ParametroIdFundoDTO parametro);
    }
}
