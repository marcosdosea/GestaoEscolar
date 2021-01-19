using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using Core.Service;

namespace Service
{
    class DisciplinaService : IDisciplinaService
    {
        private readonly SiCAEContext _context;

        public DisciplinaService(SiCAEContext context)
        {
            context = _context;
        }

        private IQueryable<Disciplina> GetQuery()
        {
            IQueryable<Disciplina> tb_autor = _context.Disciplina;
            var query = from disciplina in tb_autor
                        select disciplina;
            return query;
        }
        public Disciplina Buscar(int idDisciplina)
        {
            IEnumerable<Disciplina> disciplina = GetQuery()
                .Where(disciplina => disciplina.Nome.Equals(idDisciplina));
            return disciplina.FirstOrDefault();
        }

        public void Editar(Disciplina disciplina)
        {
            _context.Update(disciplina);
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
                .Where(disciplina => disciplina.Nome.StartsWith(nome));
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
