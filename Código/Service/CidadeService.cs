using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CidadeService : ICidadeService
    {
        private readonly SiCAEContext _context;

        public CidadeService(SiCAEContext context)
        {
            _context = context;
        }

        public int Inserir(Cidade cidade)
        {
            _context.Add(cidade);
            _context.SaveChanges();
            return cidade.idCidade;
        }
        public void Editar(Cidade cidade)
        {
            _context.Update(cidade);
            _context.SaveChanges();
        }
        public void Remover(int idCidade)
        {
            var _cidade = _context.Cidade.Find(idCidade);
            _context.Cidade.Remove(_cidade);
            _context.SaveChanges();
        }
        private IQueryable<Cidade> GetQuery()
        {
            IQueryable<Cidade> tb_cidade = _context.Cidade;
            var query = from cidade in tb_cidade
                        select cidade;
            return query;
        }
        public Cidade Obter(int idCidade)
        {
            IEnumerable<Cidade> cidades = GetQuery().Where(cidadeModel => cidadeModel.idCidade.Equals(idCidade));

            return cidades.ElementAtOrDefault(0);
        }

        public IEnumerable<Cidade> ObterPorCodIBGE(int codigo)
        {
            IEnumerable<Cidade> cidades = GetQuery()
                .Where(cidadeModel => cidadeModel.CodIbge.Equals(codigo));
            return cidades;
        }
        public IEnumerable<Cidade> ObterPorNome(string nome)
        {
            IEnumerable<Cidade> cidades = GetQuery()
                .Where(cidadeModel => cidadeModel.Nome.StartsWith(nome));
            return cidades;
        }
        public IEnumerable<Cidade> ObterPorEstado(string nome)
        {
            IEnumerable<Cidade> cidades = GetQuery()
                .Where(cidadeModel => cidadeModel.Estado.StartsWith(nome));
            return cidades;
        }

        public IEnumerable<Cidade> ObterTodos()
        {
            return GetQuery();
        }
    }
}
