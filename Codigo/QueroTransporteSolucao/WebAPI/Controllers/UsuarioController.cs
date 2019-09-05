using Microsoft.AspNetCore.Mvc;
using QueroTransporte.Model;
using QueroTransporte.Negocio;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly GerenciadorUsuario _service;
        public UsuarioController(GerenciadorUsuario service)
        {
            _service = service;
        }
        // GET: api/Usuario
        [HttpGet]
        public IActionResult Get()
        {
            var usuarios = _service.ObterTodos().Where(u => u.Tipo.Equals("CLIENTE")).ToList();
            if (usuarios.Count != 0)
                return Ok(usuarios);

            return NoContent();
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var usuario = _service.ObterPorId(id);
            if (usuario != null)
                return Ok(usuario);

            return NoContent();
        }

        // POST: api/Usuario
        [HttpPost]
        public IActionResult Post([FromBody] UsuarioModel usuario) => _service.Inserir(usuario) ? Ok(usuario) : Ok(false);

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UsuarioModel usuario) => _service.Editar(usuario) ? Ok(usuario) : Ok(false);

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => _service.Remover(id) ? Ok(true) : Ok(false);
    }
}
