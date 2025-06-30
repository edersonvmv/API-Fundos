using AutoMapper;
using CaseItau.API.ViewModels;
using CaseItau.Domain.DTO;
using CaseItau.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CaseItau.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FundoController : MainController<FundoController>
    {
        private readonly IMapper _mapper;
        private readonly IFundoService _fundoService;
        
        public FundoController(INotificador notificador,
                               IFundoService fundoService,
                               IMapper mapper,
                               ILogger<FundoController> logger) : base(notificador, logger)
        {
            _fundoService = fundoService;
            _mapper = mapper;
        }

        // GET: api/Fundo
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Usuário consultou todos os fundos");

            return CustomResponse(await _fundoService.GetFundos());

        }
                
        // GET: api/Fundo/ITAUTESTE01
        [HttpGet("{codigo}", Name = "Get")]
        public async Task<ActionResult> Get(string codigo)
        {
            _logger.LogInformation("Usuário consultou fundo {Codigo}", codigo);

            ParametroIdFundoViewModel parametroViewModel = new ParametroIdFundoViewModel { Codigo = codigo };

            return CustomResponse(await _fundoService.GetFundo(_mapper.Map<ParametroIdFundoDTO>(parametroViewModel)));
        }

        // POST: api/Fundo
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ParametroFundoViewModel parametroViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            _logger.LogInformation("Usuário criou o fundo {Codigo}", parametroViewModel.Codigo);

            return CustomResponse(await _fundoService.PostFundo(_mapper.Map<ParametroFundoDTO>(parametroViewModel)));
        }

        // PUT: api/Fundo/ITAUTESTE01
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ParametroFundoViewModel parametroViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            _logger.LogInformation("Usuário atualizou o fundo {Codigo}", parametroViewModel.Codigo);

            return CustomResponse(await _fundoService.PutFundo(_mapper.Map<ParametroFundoDTO>(parametroViewModel)));                        
        }

        [HttpPut("/patrimonio")]
        public async Task<ActionResult> MovimentarPatrimonio([FromBody] ParametroPatrimonioFundoViewModel parametroViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            _logger.LogInformation("Usuário atualizou o patrimônio do fundo {Codigo}", parametroViewModel.Codigo);

            return CustomResponse(await _fundoService.PutPatrimonioFundo(_mapper.Map<ParametroPatrimonioFundoDTO>(parametroViewModel)));                        
        }

        // DELETE: api/Fundo/ITAUTESTE01
        [HttpDelete("{codigo}")]
        public async Task<ActionResult> Delete(string codigo)
        {
            ParametroIdFundoViewModel parametroViewModel = new ParametroIdFundoViewModel { Codigo = codigo };

            _logger.LogInformation("Usuário deletou o fundo {Codigo}", parametroViewModel.Codigo);

            return CustomResponse(await _fundoService.DeleteFundo(_mapper.Map<ParametroIdFundoDTO>(parametroViewModel)));
        }

    }
}
