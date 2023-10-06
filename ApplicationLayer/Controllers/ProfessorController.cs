using DomainLayer.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApplicationLayer.Controllers
{
    /// <summary>
    /// Controller responsável por gerenciar o cadastro de professores
    /// </summary>
    [ApiController]
    [Route("api/professor")]
    public class ProfessorController : ControllerBase
    {
        private readonly ILogger<ProfessorController> _logger;
        private readonly IProfessorService _professorService;

        /// <inheritdoc />
        public ProfessorController(ILogger<ProfessorController> logger, IProfessorService professorService)
        {
            _logger = logger;
            _professorService = professorService;
        }

        /// <summary>
        /// Método responsável por listar todos os professores cadastrados
        /// </summary>
        /// <returns>200, 400</returns>
        [HttpGet]
        [SwaggerOperation("lista os professores")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        public async Task<ActionResult<IEnumerable<Professor>>> ListaAsync()
        {
            var professores = await _professorService.Lista();

            return Ok(professores);
        }

        /// <summary>
        /// Método responsável por cadastrar um professorer
        /// </summary>
        /// <param name="professor"></param>
        /// <returns>201, 400</returns>
        [HttpPost]
        [SwaggerOperation("Registra professor")]
        [SwaggerResponse(201)]
        [SwaggerResponse(400)]  
        public async Task<ActionResult> RegistraAsync([FromBody] Professor professor)
        {
            if (professor.Conhecimentos.Count() <= 0)
            {
                return BadRequest();
            }

            await _professorService.Registra(professor);

            return Created("", ""); // professor
        }

        /// <summary>
        /// Método responsável por buscar professor pelo nome
        /// </summary>
        /// <param name="nome">Nome do professor</param>
        /// <returns>200, 400</returns>
        [HttpGet("{nome}")]
        [SwaggerOperation("Busca o(s) professor(es)")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        public async Task<ActionResult<IEnumerable<Professor>>> BuscaAsync(string nome)
        {
            var professores = await _professorService.Busca(nome);

            return Ok(professores);
        }

        /// <summary>
        /// Método responsável por atualizar um professor no sistema
        /// </summary>
        /// <param name="professor">Objeto de professor</param>
        /// <returns>204, 400</returns>
        [HttpPatch()]
        [SwaggerOperation("atualiza professor")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        public async Task<ActionResult> AtualizaAsync([FromBody]Professor professor)
        {
            await _professorService.Atualiza(professor);

            return NoContent();
        }

        /// <summary>
        /// Método responsável por apagar um professor no sistema
        /// </summary>
        /// <param name="id">Identificador único do professor</param>
        /// <returns>204, 400</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation("apaga um professore")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        public async Task<ActionResult> ApagaAsync([FromRoute] Guid id)
        {
            await _professorService.Apaga(id);

            return NoContent();
        }
    }
}
