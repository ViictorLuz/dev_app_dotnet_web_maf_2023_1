using ApplicationLayer;
using Dapper;
using DomainLayer.Interfaces.Infrastructure;
using DomainLayer.Interfaces.Repository;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace InfrastructureLayer.Data.Repository
{
	public class ProfessorRepository : IProfessorRepository
	{
		private readonly IDbContext _context;
		private readonly ILogger<ProfessorRepository> _logger;

		public ProfessorRepository(ILogger<ProfessorRepository> logger, IDbContext context)
		{
			_logger = logger;
			_context = context;
		}

		public async Task Registra(Professor professor)
		{
			_logger.LogInformation($"[ProfessorRepository]-[Registra] -> [Start]: Payload -> {JsonSerializer.Serialize(professor)}");

			using var connection = _context.CreateConnection;

			const string query = "INSERT INTO professor(Nome, Matricula, Conhecimentos) VALUES (@Nome, @Matricula, @Conhecimentos);";
			var parameters = new
			{
				professor.Nome,
				professor.Matricula,
				professor.Conhecimentos
			};

			try
			{
				await connection.ExecuteAsync(query, parameters);
			}
			catch (Exception exception)
			{
				_logger.LogError($"[ProfessorRepository]-[Registra] -> [Exception]: Message -> {exception.Message}");
				_logger.LogError($"[ProfessorRepository]-[Registra] -> [InnerException]: Message -> {exception.InnerException}");
				throw;
			}

			_logger.LogInformation("[ProfessorRepository]-[Registra] [Finish]");
		}

		public async Task<IEnumerable<Professor>> Lista()
		{
			_logger.LogInformation($"[ProfessorRepository]-[Lista] -> [Start]");

			using var connection = _context.CreateConnection;

			const string query = "SELECT * FROM professor;";

			try
			{
				var result = await connection.QueryAsync<Professor>(query);

				_logger.LogInformation("[ProfessorRepository]-[Lista] -> [Finish]");
				return result;
			}
			catch (Exception exception)
			{
				_logger.LogError($"[ProfessorRepository]-[Lista] -> [Exception]: Message -> {exception.Message}");
				_logger.LogError($"[ProfessorRepository]-[Lista] -> [InnerException]: Message -> {exception.InnerException}");
				throw;
			}
		}

		public async Task Apaga(Guid id)
		{
			_logger.LogInformation($"[ProfessorRepository]-[Apaga] -> [Start]: GUID -> {id}");

			using var connection = _context.CreateConnection;

			const string query = "DELETE FROM professor WHERE Id = @Id";
			var param = new
			{
				Id = id
			};

			try
			{
				await connection.ExecuteAsync(query, param);
			}
			catch (Exception exception)
			{
				_logger.LogError($"[ProfessorRepository]-[Apaga] -> [Exception]: Message -> {exception.Message}");
				_logger.LogError($"[ProfessorRepository]-[Apaga] -> [InnerException]: Message -> {exception.InnerException}");
				throw;
			}

			_logger.LogInformation("[ProfessorRepository]-[Apaga] -> [Finish]");
		}

		public async Task Atualiza(Professor professor)
		{
			_logger.LogInformation($"[ProfessorRepository]-[Atualiza] -> [Start]: Payload -> {JsonSerializer.Serialize(professor)}");

			using var connection = _context.CreateConnection;

			const string query = "UPDATE aluno SET Nome = @Nome, Conhecimentos = @Conhecimentos WHERE Matricula = @Matricula;";
			var parameters = new
			{
				professor.Nome,
				professor.Matricula,
				professor.Conhecimentos
			};

			try
			{
				await connection.ExecuteAsync(query, parameters);
			}
			catch (Exception exception)
			{
				_logger.LogError($"[ProfessorRepository]-[Atualiza] -> [Exception]: Message -> {exception.Message}");
				_logger.LogError($"[ProfessorRepository]-[Atualiza] -> [InnerException]: Message -> {exception.InnerException}");
				throw;
			}

			_logger.LogInformation("[ProfessorRepository]-[Atualiza] -> [Finish]");
		}

		public async Task<IEnumerable<Professor>> Busca(string nome)
		{
			_logger.LogInformation($"[ProfessorRepository]-[Busca] -> [Start]: Nome -> {nome}");

			using var connection = _context.CreateConnection;

			const string query = "SELECT * FROM professor WHERE nome LIKE @Nome;";
			var param = new
			{
				Nome = $"%{nome}%"
			};

			try
			{
				var result = await connection.QueryAsync<Professor>(query, param);

				_logger.LogInformation("[ProfessorRepository]-[Busca] -> [Finish]");
				return result;
			}
			catch (Exception exception)
			{
				_logger.LogError($"[ProfessorRepository]-[Busca] -> [Exception]: Message -> {exception.Message}");
				_logger.LogError($"[ProfessorRepository]-[Busca] -> [InnerException]: Message -> {exception.InnerException}");
				throw;
			}
		}



		// persistência em memória
		private static void Persiste(Professor professor)
		{
			//_professores.Add(professor);
		}
	}
}
