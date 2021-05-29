using DesafioSoftplan.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioSoftplan.Controllers
{

    [ApiController]
    public class TaxaJurosController : ControllerBase
    {

        private readonly IJurosService _service;

        public TaxaJurosController(IJurosService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna a taxa de juros.
        /// </summary>
        [HttpGet]
        [Route("TaxaJuros")]
        public ActionResult<string> TaxaJuros()
        {
            var taxa = _service.GetTaxaJuros();
            return Ok(taxa.ToString("N2"));
        }

    }
}
