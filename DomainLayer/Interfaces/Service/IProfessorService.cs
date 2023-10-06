using ApplicationLayer;

namespace DomainLayer.Interfaces.Service
{
	public interface IProfessorService
	{
		Task Registra(Professor professor);
		Task<IEnumerable<Professor>> Lista();
		Task<IEnumerable<Professor>> Busca(string nome);
		Task Atualiza(Professor professor);
		Task Apaga(Guid id);
	}
}