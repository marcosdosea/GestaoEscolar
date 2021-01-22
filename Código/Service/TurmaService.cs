using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using Core.Service;

namespace Service
{
    public class TurmaService : ITurmaService
    {
        private readonly SiCAEContext _context;
        public TurmaService(SiCAEContext context)
        {
            context = _context;
        }
        private IQueryable<Turma> GetQuery()
        {
            IQueryable<Turma> tb_autor = _context.Turma;
            var query = from turma in tb_autor
                        select turma;
            return query;
        }

        public Turma Buscar(int idTurma)
        {
            IEnumerable<Turma> turma = GetQuery()
                .Where(turma => turma.NomeTurma.Equals(idTurma));
            return turma.FirstOrDefault();
        }

        public void Editar(Turma turma)
        {
            _context.Update(turma);
            _context.SaveChanges();
        }

        public int Inserir(Turma turma)
        {
            _context.Add(turma);
            _context.SaveChanges();
            return turma.IdTurma;
        }

        public IEnumerable<Turma> ObterPorNome(string nome)
        {
            IEnumerable<Turma> turma = GetQuery()
                .Where(turma => turma.NomeTurma.StartsWith(nome));
            return turma;
        }

        public IEnumerable<Turma> ObterTodos()
        {
            return GetQuery();
        }

        public void Remover(int idTurma)
        {
            var _turma = _context.Turma.Find(idTurma);
            _context.Turma.Remove(_turma);
            _context.SaveChanges();
        }
    }
}
