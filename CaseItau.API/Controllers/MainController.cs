using CaseItau.Domain.Interfaces;
using CaseItau.Domain.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CaseItau.API.Controllers
{
    public class MainController<T> : ControllerBase
    {
        protected readonly INotificador _notificador;
        protected readonly ILogger<T> _logger;
        protected MainController(INotificador notificador,
                                 ILogger<T> logger)
        {
            _notificador = notificador;
            _logger = logger;       
        }
        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }
        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }
            return BadRequest(new
            {
                success = false,
                errors = _notificador.ObterNotificacoes().Select(x => x.Mensagem)
            });
        }
        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);
            return CustomResponse();
        }
        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(erroMsg);
            }
        }
        protected void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}
