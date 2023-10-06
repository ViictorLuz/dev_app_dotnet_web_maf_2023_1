using ApplicationLayer;
using DomainLayer.Interfaces.Repository;
using DomainLayer.Interfaces.Service;

namespace ServiceLayer
{
	public class ProfessorService : IProfessorService
	{
		private readonly IProfessorRepository _repository;

		public ProfessorService(IProfessorRepository repository) => _repository = repository;
		
		public async Task Apaga(Guid id) => await _repository.Apaga(id);
		
		public async Task Atualiza(Professor professor) => await _repository.Atualiza(professor);
		
		public async Task<IEnumerable<Professor>> Busca(string nome) => await _repository.Busca(nome);
		
		public async Task<IEnumerable<Professor>> Lista() => await _repository.Lista();
		
		public async Task Registra(Professor professor) => await _repository.Registra(professor);




	}
}
