using CaseItau.Domain.DTO;
using CaseItau.Domain.Models;

namespace CaseItau.Domain.Interfaces
{
    public interface IFundoRepository : IDisposable
    {
        Task<List<Fundo>> GetFundos();
        Task<Fundo> GetFundo(ParametroIdFundoDTO parametro);
        Task<Fundo> GetFundo(ParametroFundoExistDTO parametro);
        Task<bool> PutPatrimonioFundo(ParametroPatrimonioFundoDTO parametro);
        Task<bool> PutFundo(ParametroFundoDTO parametro);
        Task<bool> PostFundo(ParametroFundoDTO parametro);
        Task<bool> DeleteFundo(ParametroIdFundoDTO parametro);
    }
}
