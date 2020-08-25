using Microsoft.AspNetCore.Mvc;
using QueroTransporte.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly GerenciadorVeiculo _service;
        public VeiculoController(GerenciadorVeiculo service)
        {
            _service = service;
        }
        // GET: api/Veiculo
        [HttpGet]
        public IActionResult Get()
        {
            var veiculos = _service.ObterTodos();
            if (veiculos.Count != 0)
                return Ok(veiculos);

            return NoContent();
        }

        // GET: api/Veiculo/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var veiculo = _service.ObterPorId(id);
            if (veiculo != null)
                return Ok(veiculo);

            return NoContent();
        }

        // POST: api/Veiculo
        [HttpPost]
        public IActionResult Post([FromBody] VeiculoModel veiculo) => _service.Inserir(veiculo) ? Ok(veiculo) : Ok(false);

        // PUT: api/Veiculo/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] VeiculoModel veiculo) => _service.Editar(veiculo) ? Ok(veiculo) : Ok(false);

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => _service.Remover(id) ? Ok(true) : Ok(false);
    }
}
