using Microsoft.AspNetCore.Mvc;
using QueroTransporte.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrotaController : ControllerBase
    {
        private readonly GerenciadorFrota _service;
        public FrotaController(GerenciadorFrota service)
        {
            _service = service;
        }

        // GET: api/Frota
        [HttpGet]
        public IActionResult Get()
        {
            var frotas = _service.ObterTodos();
            if (frotas.Count != 0)
                return Ok(frotas);

            return NoContent();
        }

        // GET: api/Frota/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var frota = _service.ObterPorId(id);
            if (frota != null)
                return Ok(frota);

            return NoContent();
        }

        // POST: api/Frota
        [HttpPost]
        public IActionResult Post([FromBody] FrotaModel frota) => _service.Inserir(frota) ? Ok(frota) : Ok(false);

        // PUT: api/Frota/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] FrotaModel frota) => _service.Editar(frota) ? Ok(frota) : Ok(false);

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => _service.Remover(id) ? Ok(true) : Ok(false);
    }
}
