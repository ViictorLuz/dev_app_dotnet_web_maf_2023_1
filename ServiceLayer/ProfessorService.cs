using DomainLayer.Interfaces.Service;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ProfessorService : IProfessorService
    {
        private static List<Professor> _professores = default!;
        public ProfessorService()
        {
            _professores = new List<Professor>();
        }

        public Professor RegistraProfessor(Professor professor)
        {
            // Gera o ID
            professor.Id = Guid.NewGuid();

            // Persisto o professor no nosso array estático
            PersisteProfessor(professor);

            // Retorna o professor cadastro com o GUID
            return new Professor();
        }

        public IEnumerable<Professor> ListaProfessores()
        {
            return _professores;
        }

        public IEnumerable<Professor> BuscaProfessor(string nome)
        {
            /*
            return _professores.Find(professor => professor.Nome.Equals(
                value: nome,
                comparisonType: StringComparison.InvariantCultureIgnoreCase)
            )!;*/

            return _professores.FindAll(prof => prof.Nome.ToLower().Contains(nome.ToLower()));
        }

        Professor IProfessorService.AtualizarProfessor(Professor professor)
        {
            var prof = _professores.Find(professor => professor.Id.ToString().Equals(professor.Id.ToString()))!;

            var idx = _professores.IndexOf(prof);

            _professores[idx].Nome = professor.Nome;
            _professores[idx].Conhecimentos = professor.Conhecimentos;

            return professor;
        }

        void IProfessorService.ApagaProfessor(Guid id)
        {
            var professor = _professores.Find(prof => prof.Id == id);

            if (professor != null)
            { 
                _professores.Remove(professor);
            }
        }
        
        // Persistencia em memória
        private void PersisteProfessor(Professor professor)
        {
            _professores.Add(professor);
        }
    }
}
