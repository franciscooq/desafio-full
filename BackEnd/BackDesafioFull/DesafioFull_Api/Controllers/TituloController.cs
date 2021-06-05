using DesafioFull_Application.Contracts;
using DesafioFull_Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesafioFull_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TituloController : ControllerBase
    {
        private readonly ITituloBusiness _tituloBusiness;

        public TituloController(ITituloBusiness tituloBusiness)
        {
            _tituloBusiness = tituloBusiness;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _tituloBusiness.ObterTodos();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _tituloBusiness.ObterPorId(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TituloRequest request)
        {
            await Task.Yield();

            _tituloBusiness.NovoTitulo(request);

            return Ok();
        }
    }
}
