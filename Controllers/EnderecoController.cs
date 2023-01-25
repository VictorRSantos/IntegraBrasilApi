using System.Net;
using IntegraBrasilApi.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace IntegraBrasilApi.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecooService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecooService = enderecoService;
        }

        [HttpGet("buscar/{cep}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarEndereco([FromRoute] string cep)
        {

            var response = await _enderecooService.BuscarEndereco(cep);

            if (response.CodigoHttp == HttpStatusCode.OK)
            {
                return Ok(response.DadosRetorno);
            }
            else
            {
                return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
            }

        }

    }
}