using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class DisciplinaService : IDisciplinaService
    {
        private readonly SiCAEContext _context;

        public DisciplinaService(SiCAEContext context)
        {
             _context = context;
        }

        private IQueryable<Disciplina> GetQuery()
        {
            IQueryable<Disciplina> tb_disciplina = _context.Disciplina;
            var query = from disciplina in tb_disciplina
                        select disciplina;
            return query;
        }
        public Disciplina Obter(int idDisciplina)
        {
            IEnumerable<Disciplina> disciplinas = GetQuery()
                .Where(disciplinaModel => disciplinaModel.IdDisciplina.Equals(idDisciplina));

            return disciplinas.ElementAtOrDefault(0);
        }
        public void Editar(Disciplina disciplina)
        {
            _context.Disciplina.Update(disciplina);
            _context.SaveChanges();
        }

        public int Inserir(Disciplina disciplina)
        {
            _context.Add(disciplina);
            _context.SaveChanges();
            return disciplina.IdDisciplina;
        }

        public IEnumerable<Disciplina> ObterPorNome(string nome)
        {
            IEnumerable<Disciplina> disciplinas = GetQuery()
                .Where(disciplinaModel => disciplinaModel.Nome.StartsWith(nome));
            return disciplinas;
        }

        public IEnumerable<Disciplina> ObterTodos()
        {
            return GetQuery();
        }

        public void Remover(int idDisciplina)
        {
            var _disciplina = _context.Disciplina.Find(idDisciplina);
            _context.Disciplina.Remove(_disciplina);
            _context.SaveChanges();

        }
    }
}
