using Microsoft.AspNetCore.Mvc;
using QueroTransporte.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoristaController : ControllerBase
    {
        private readonly GerenciadorMotorista _service;
        public MotoristaController(GerenciadorMotorista service)
        {
            _service = service;
        }
        // GET: api/Motorista
        [HttpGet]
        public IActionResult Get()
        {
            var motoristas = _service.ObterTodos();
            if (motoristas.Count != 0)
                return Ok(motoristas);

            return NoContent();
        }

        // GET: api/Motorista/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var motorista = _service.ObterPorId(id);
            if (motorista != null)
                return Ok(motorista);

            return NoContent();
        }

        // POST: api/Motorista
        [HttpPost]
        public IActionResult Post([FromBody] MotoristaModel motorista) => _service.Inserir(motorista) ? Ok(motorista) : Ok(false);

        // PUT: api/Motorista/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MotoristaModel motorista) => _service.Editar(motorista) ? Ok(motorista) : Ok(false);

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => _service.Remover(id) ? Ok(true) : Ok(false);
    }
}
