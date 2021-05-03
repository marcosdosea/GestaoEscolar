using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class AulaService : IAulaService
    {
        private readonly SiCAEContext _context;

        public AulaService(SiCAEContext context)
        {
            _context = context;
        }

        public int Inserir(Aula aula)
        {
            _context.Add(aula);
            _context.SaveChanges();
            return aula.IdAula;
        }
        public void Editar(Aula aula)
        {
            _context.Update(aula);
            _context.SaveChanges();
        }
        public void Remover(int idAula)
        {
            var _aula = _context.Aula.Find(idAula);
            _context.Aula.Remove(_aula);
            _context.SaveChanges();
        }
        private IQueryable<Aula> GetQuery()
        {
            IQueryable<Aula> tb_aula = _context.Aula;
            var query = from aula in tb_aula
                        select aula;
            return query;
        }
        public int GetAulas()
        {
            return _context.Aula.Count();
        }
        public Aula Obter(int idAula)
        {
            IEnumerable<Aula> aulas = GetQuery().Where(aulaModel => aulaModel.IdAula.Equals(idAula));

            return aulas.ElementAtOrDefault(0);
        }

        public IEnumerable<Aula> ObterPorNome(string nome)
        {
            IEnumerable<Aula> aulas = GetQuery()
                .Where(aulaModel => aulaModel.Conteudo.StartsWith(nome));
            return aulas;
        }

        public IEnumerable<Aula> ObterTodos()
        {
            return GetQuery();
        }

        public IEnumerable<AulaDTO> ObterPorNomeOrdenadoDescending(string nome)
        {
            IQueryable<Aula> tb_aula = _context.Aula;
            var query = from aula in tb_aula
                        where nome.StartsWith(nome)
                        orderby aula.Conteudo descending
                        select new AulaDTO
                        {
                            Conteudo = aula.Conteudo
                        };
            return query;
        }
    }
}
