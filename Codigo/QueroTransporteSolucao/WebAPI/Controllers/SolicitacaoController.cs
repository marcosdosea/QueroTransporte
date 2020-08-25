using Microsoft.AspNetCore.Mvc;
using QueroTransporte.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitacaoController : ControllerBase
    {
        private readonly GerenciadorSolicitacao _service;
        public SolicitacaoController(GerenciadorSolicitacao service)
        {
            _service = service;
        }
        // GET: api/Solicitacao
        [HttpGet]
        public IActionResult Get()
        {
            var solicitacoes = _service.ObterTodos();
            if (solicitacoes.Count != 0)
                return Ok(solicitacoes);

            return NoContent();
        }

        // GET: api/Solicitacao/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var solicitacao = _service.ObterPorId(id);
            if (solicitacao != null)
                return Ok(solicitacao);

            return NoContent();
        }

        // POST: api/Solicitacao
        [HttpPost]
        public IActionResult Post([FromBody] SolicitacaoVeiculoModel solicitacao) => _service.Inserir(solicitacao) ? Ok(solicitacao) : Ok(false);

        // PUT: api/Solicitacao/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SolicitacaoVeiculoModel solicitacao) => _service.Editar(solicitacao) ? Ok(solicitacao) : Ok(false);

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => _service.Remover(id) ? Ok(true) : Ok(false);
    }
}
