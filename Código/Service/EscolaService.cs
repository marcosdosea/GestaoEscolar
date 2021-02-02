using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using Core.DTO;
using Core.Service;

namespace Service
{
    public class EscolaService : IEscolaService
    {
        private readonly SiCAEContext _context;

        public EscolaService(SiCAEContext context)
        {
            _context = context;
        }

        public int Inserir(Escola escola)
        {
            _context.Add(escola);
            _context.SaveChanges();
            return escola.IdEscola;
        }
        public void Editar(Escola escola)
        {
            _context.Update(escola);
            _context.SaveChanges();
        }
        public void Remover(int idEscola)
        {
            var _escola = _context.Escola.Find(idEscola);
            _context.Escola.Remove(_escola);
            _context.SaveChanges();
        }
        private IQueryable<Escola> GetQuery()
        {
            IQueryable<Escola> tb_escola = _context.Escola;
            var query = from escola in tb_escola
                        select escola;
            return query;
        }
        public int GetHorarios()
        {
            return _context.Escola.Count();
        }

        public Escola Obter(int idEscola)
        {
            IEnumerable<Escola> escola = GetQuery()
                .Where(escola => escola.Nome.Equals(idEscola));
            return escola.FirstOrDefault();
        }

        public IEnumerable<Escola> ObterPorNome(string nome)
        {
            IEnumerable<Escola> escolas = GetQuery()
                .Where(escolaModel => escolaModel.Nome.StartsWith(nome));
            return escolas;
        }

        public IEnumerable<Escola> ObterTodos()
        {
            return GetQuery();
        }
    }
}
