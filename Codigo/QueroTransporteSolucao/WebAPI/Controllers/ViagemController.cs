using Microsoft.AspNetCore.Mvc;
using QueroTransporte.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViagemController : ControllerBase
    {
        private readonly GerenciadorViagem _service;
        public ViagemController(GerenciadorViagem service)
        {
            _service = service;
        }
        // GET: api/Viagem
        [HttpGet]
        public IActionResult Get()
        {
            var viagens = _service.ObterTodos();
            if (viagens.Count != 0)
                return Ok(viagens);

            return NoContent();
        }

        // GET: api/Viagem/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var viagem = _service.ObterPorId(id);
            if (viagem != null)
                return Ok(viagem);

            return NoContent();
        }

        // POST: api/Viagem
        [HttpPost]
        public IActionResult Post([FromBody] ViagemModel viagem) => _service.Inserir(viagem) ? Ok(viagem) : Ok(false);

        // PUT: api/Viagem/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ViagemModel viagem) => _service.Editar(viagem) ? Ok(viagem) : Ok(false);

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => _service.Remover(id) ? Ok(true) : Ok(false);
    }
}
