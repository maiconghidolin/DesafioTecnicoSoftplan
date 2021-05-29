using DesafioSoftplan.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DesafioSoftplan.Controllers
{

    [ApiController]
    public class CalculaJurosController : ControllerBase
    {

        private readonly IJurosService _service;
        
        public CalculaJurosController(IJurosService service)
        {
            _service = service;
        }

        /// <summary>
        /// Faz o cálculo, em memória, de juros compostos.
        /// </summary>
        [HttpGet]
        [Route("CalculaJuros")]
        public ActionResult<string> CalculaJuros(double valorInicial, int meses)
        {
            // somente para efeito de testes
            if (valorInicial <= 0)
                return BadRequest("O valor inicial deve ser maior que zero");

            // somente para efeito de testes
            if (meses <= 0)
                return BadRequest("O número de meses deve ser maior que zero");

            var juros = _service.GetTaxaJuros();
            var valorFinal = valorInicial * Math.Pow((1 + juros), meses);
            valorFinal = Math.Truncate(valorFinal * 100) / 100;
            return Ok(valorFinal.ToString("N2"));
        }

        /// <summary>
        /// Retorna a url do repositório onde se encontra o código-fonte.
        /// </summary>
        [HttpGet]
        [Route("ShowMeTheCode")]
        public ActionResult<string> ShowMeTheCode()
        {
            var link = "https://github.com/maiconghidolin/DesafioTecnicoSoftplan";
            return Ok(link);
        }

    }
}
