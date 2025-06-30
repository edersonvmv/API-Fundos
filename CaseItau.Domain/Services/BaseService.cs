using CaseItau.Domain.Interfaces;
using CaseItau.Domain.Notificacoes;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace CaseItau.Domain.Services
{
    public abstract class BaseService<T>
    {
        protected readonly INotificador _notificador;
        protected readonly ILogger<T> _logger;
        protected BaseService(INotificador notificador, ILogger<T> logger)
        {
            _notificador = notificador;
            _logger = logger;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }
        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}
