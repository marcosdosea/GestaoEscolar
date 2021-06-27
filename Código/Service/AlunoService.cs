using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class AlunoService : IAlunoService
    {
        private readonly SiCAEContext _context;

        public AlunoService(SiCAEContext context)
        {
            _context = context;
        }

        public int Inserir(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
            return aluno.IdAluno;
        }
        public void Editar(Aluno aluno)
        {
            _context.Update(aluno);
            _context.SaveChanges();
        }
        public void Remover(int idAluno)
        {
            var _aluno = _context.Aluno.Find(idAluno);
            _context.Aluno.Remove(_aluno);
            _context.SaveChanges();
        }
        private IQueryable<Aluno> GetQuery()
        {
            IQueryable<Aluno> tb_aluno = _context.Aluno;
            var query = from aluno in tb_aluno
                        select aluno;
            return query;
        }
        public int GetAlunos()
        {
            return _context.Aluno.Count();
        }
        public Aluno Obter(int idAluno)
        {
            IEnumerable<Aluno> alunos = GetQuery().Where(alunoModel => alunoModel.IdAluno.Equals(idAluno));

            return alunos.ElementAtOrDefault(0);
        }

        public IEnumerable<Aluno> ObterPorNome(string nome)
        {
            IEnumerable<Aluno> alunos = GetQuery()
                .Where(alunoModel => alunoModel.Nome.StartsWith(nome));
            return alunos;
        }

        public IEnumerable<Aluno> ObterTodos()
        {
            return GetQuery();
        }

        public IEnumerable<AlunoDTO> ObterPorNomeOrdenadoDescending(string nome)
        {
            //IQueryable<Aluno> tb_aluno = _context.Aluno;
            var query = from aluno in _context.Aluno
                        where nome.StartsWith(nome)
                        orderby aluno.Nome descending
                        select new AlunoDTO
                        {
                            Nome = aluno.Nome
                        };
            return query;
        }
    }
}
