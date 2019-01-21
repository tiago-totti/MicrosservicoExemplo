using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicrosservicoExemplo.Application.UseCases.Contas;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicrosservicoExemplo.API.Controllers
{
    [Route("[controller]")]
    public class TransacoesController : Controller
    {
        private readonly ITransferenciaUseCase _transferenciaUseCase;

        public TransacoesController(ITransferenciaUseCase transferenciaUseCase)
        {
            _transferenciaUseCase = transferenciaUseCase;
        }
        /// <summary>
        /// Executa uma transação de transferência do valor informado entre as contas especificadas
        /// </summary>
        /// <param name="request">Dados da transferência</param>
        /// <returns></returns>
        [Route("transferencia")]
        [HttpPost]
        public ActionResult PostTransferencia([FromBody]TransferenciaRequest request)
        {
            _transferenciaUseCase.Executar(request);
            return Ok();
        }
    }
}
