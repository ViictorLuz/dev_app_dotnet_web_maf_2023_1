using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    [ApiController]
    [Route("aluno")]
    public class AlunoController : ControllerBase
    {         
        private readonly ILogger<AlunoController> _logger;

        public AlunoController(ILogger<AlunoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<Aluno> Get()
        {
            var aluno = new Aluno
            {
                Matricula = 12345,
                Nome = "Victor",
                DataNascimento = new DateOnly(1996, 3, 4)
            };

            return Ok(aluno);
        }
    }
}