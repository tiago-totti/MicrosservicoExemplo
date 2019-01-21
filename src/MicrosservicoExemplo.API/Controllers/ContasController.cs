using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using MicrosservicoExemplo.Application.UseCases.Contas;
using System.Collections.Generic;

namespace MicrosservicoExemplo.API.Controllers
{
    [Route("[controller]")]
    public class ContasController:Controller
    {
        private readonly ICadastrarContaCorrenteUseCase _cadastrarContaCorrenteUseCase;

        public ContasController(ICadastrarContaCorrenteUseCase cadastrarContaCorrenteUseCase)
        {
            _cadastrarContaCorrenteUseCase = cadastrarContaCorrenteUseCase;
        }

        /// <summary>
        /// Cria uma nova conta corrente
        /// </summary>
        /// <param name="request">Parametros para criação da conta corrente</param>
        /// <response code="201">Conta corrente criada com sucesso</response>
        /// <response code="422">Ocorreu um erro de validação durante a criação da conta corrente</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(IEnumerable<Notification>), 422)]
        public ActionResult Post([FromBody]CadastrarContaCorrenteRequest request)
        {
            var result = _cadastrarContaCorrenteUseCase.Executar(request);
            return Created("/", new { result.Agencia, result.Conta });
        }
    }
}
