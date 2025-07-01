using CaseItau.Domain.DTO;
using CaseItau.Domain.Interfaces;
using CaseItau.Domain.Models;
using CaseItau.Infra.Queries;
using Dapper;
using System.Data;

namespace CaseItau.Infra.Repositories
{
    public class FundoRepository : IFundoRepository
    {
        private readonly IDbConnection _connection;

        public FundoRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<Fundo> GetFundo(ParametroIdFundoDTO parametro)
        {
            return await _connection.QueryFirstOrDefaultAsync<Fundo>(FundoQuery.SelectId, new { CODIGO = parametro.Codigo });
        }

        public async Task<List<Fundo>> GetFundos()
        {
            return (await _connection.QueryAsync<Fundo>(FundoQuery.SelectAll)).ToList();
        }

        public async Task<Fundo> GetFundo(ParametroFundoExistDTO parametro)
        {
            return await _connection.QueryFirstOrDefaultAsync<Fundo>(FundoQuery.SelectValid, new
            {
                CODIGO = parametro.Codigo,
                CNPJ = parametro.Cnpj

            });
        }

        public async Task<bool> PostFundo(ParametroFundoDTO parametro)
            {
                await _connection.ExecuteAsync(FundoQuery.Insert, new
                {
                    CODIGO = parametro.Codigo,
                    NOME = parametro.Nome,
                    CNPJ = parametro.Cnpj,
                    CODIGO_TIPO = parametro.CodigoTipo,
                    PATRIMONIO = parametro.Patrimonio
                });

                return true;
            }

            public async Task<bool> PutFundo(ParametroFundoDTO parametro)
            {
                await _connection.ExecuteAsync(FundoQuery.Update, new
                {
                    CODIGO = parametro.Codigo,
                    NOME = parametro.Nome,
                    CNPJ = parametro.Cnpj,
                    CODIGO_TIPO = parametro.CodigoTipo,
                    PATRIMONIO = parametro.Patrimonio
                });

                return true;
            }

            public async Task<bool> PutPatrimonioFundo(ParametroPatrimonioFundoDTO parametro)
            {
                await _connection.ExecuteAsync(FundoQuery.UpdatePatrimonio, new
                {
                    CODIGO = parametro.Codigo,
                    PATRIMONIO = parametro.Patrimonio
                });

                return true;
            }

            public async Task<bool> DeleteFundo(ParametroIdFundoDTO parametro)
            {
                await _connection.ExecuteAsync(FundoQuery.Delete, new { CODIGO = parametro.Codigo });

                return true;
            }

            public void Dispose()
            {
                _connection?.Dispose();
            }
        }
    }
