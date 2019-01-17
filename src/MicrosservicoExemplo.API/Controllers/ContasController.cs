using Microsoft.AspNetCore.Mvc;
using MicrosservicoExemplo.Application.UseCases.Contas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [Route("")]
        public ActionResult Post([FromBody]CadastrarContaCorrenteRequest request)
        {
            var result = _cadastrarContaCorrenteUseCase.Executar(request);
            return Created("/", new { result.Agencia, result.Conta });
        }
    }
}
