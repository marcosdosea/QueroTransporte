using Microsoft.AspNetCore.Mvc;
using QueroTransporte.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RotaController : ControllerBase
    {
        private readonly GerenciadorRota _service;
        public RotaController(GerenciadorRota service)
        {
            _service = service;
        }
        // GET: api/Rota
        [HttpGet]
        public IActionResult Get()
        {
            var rotas = _service.ObterTodos();
            if (rotas.Count != 0)
                return Ok(rotas);

            return NoContent();
        }

        // GET: api/Rota/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var rota = _service.ObterPorId(id);
            if (rota != null)
                return Ok(rota);

            return NoContent();
        }

        // POST: api/Rota
        [HttpPost]
        public IActionResult Post([FromBody] RotaModel rota) => _service.Inserir(rota) ? Ok(rota) : Ok(false);

        // PUT: api/Rota/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RotaModel rota) => _service.Editar(rota) ? Ok(rota) : Ok(false);

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => _service.Remover(id) ? Ok(true) : Ok(false);
    }
}
