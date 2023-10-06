using ApplicationLayer;

namespace DomainLayer.Interfaces.Repository
{
	public interface IProfessorRepository
	{
		Task Registra(Professor professor);
		Task<IEnumerable<Professor>> Lista();
		Task<IEnumerable<Professor>> Busca(string nome);
		Task Atualiza(Professor professor);
		Task Apaga(Guid id);
	}
}