using CaseItau.Domain.DTO;
using CaseItau.Domain.Interfaces;
using CaseItau.Domain.Models;
using Microsoft.Extensions.Logging;
using System;

namespace CaseItau.Domain.Services
{
    public class FundoService : BaseService<FundoService>, IFundoService
    {
        private readonly IFundoRepository _fundoRepository;
        public FundoService(INotificador notificador,
                            IFundoRepository fundoRepository,
                            ILogger<FundoService> logger) : base(notificador, logger)
        {
            _fundoRepository = fundoRepository;
        }

        public async Task<List<Fundo>> GetFundos()
        {
            return await _fundoRepository.GetFundos();
        }

        public async Task<Fundo> GetFundo(ParametroIdFundoDTO parametro)
        {
            try
            {
                var fundo = await _fundoRepository.GetFundo(parametro);

                if (fundo == null)
                {
                    Notificar("Código do fundo inválido");
                    _logger.LogInformation("Fundo {Codigo} não encontrado na consulta", parametro.Codigo);
                }
                else
                    _logger.LogInformation("Fundo {Codigo} retornado com sucesso!", parametro.Codigo);

                return fundo;

            }
            catch (Exception ex)
            {
                Notificar("fundo não encontrado");
                _logger.LogInformation("GetFundo - Erro: {Message}", ex.Message);

                return new Fundo();
            }
        }

        public async Task<Fundo> PostFundo(ParametroFundoDTO parametro)
        {
            if (await ExistFundoOrCnpj(parametro)) return new Fundo();

            await _fundoRepository.PostFundo(parametro);

            return await GetFundo(new ParametroIdFundoDTO { Codigo = parametro.Codigo });
        }

        public async Task<Fundo> PutFundo(ParametroFundoDTO parametro)
        {
            if (await ExistFundoOrCnpj(parametro)) return new Fundo();

            await _fundoRepository.PutFundo(parametro);

            return await GetFundo(new ParametroIdFundoDTO { Codigo = parametro.Codigo });
        }

        public async Task<Fundo> PutPatrimonioFundo(ParametroPatrimonioFundoDTO parametro)
        {
            await _fundoRepository.PutPatrimonioFundo(parametro);

            return await GetFundo(new ParametroIdFundoDTO { Codigo = parametro.Codigo });
        }

        public async Task<bool> DeleteFundo(ParametroIdFundoDTO parametro)
        {
            return await _fundoRepository.DeleteFundo(parametro);
        }

        private async Task<bool> ExistFundoOrCnpj(ParametroFundoDTO parametro)
        {
            var fundo = await _fundoRepository.GetFundo(new ParametroFundoExistDTO
            {
                Codigo = parametro.Codigo,
                Cnpj = parametro.Cnpj
            });

            if (fundo != null)
            {
                Notificar("Código do fundo ou CNPJ já existe");
                _logger.LogInformation("Fundo: {Codigo} ou Cnpj: {Cnpj} já existe na base de dados", parametro.Codigo, parametro.Cnpj);

                return true;
            }
            else
                return false;

        }

        public void Dispose()
        {
            _fundoRepository?.Dispose();
        }
    }
}