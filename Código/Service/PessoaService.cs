using System;
using System.Collections.Generic;
using System.Text;
using Core;
using System.Linq;
using Core.Service;

namespace Service
{
    public class PessoaService : IPessoaService
    {

        private readonly SiCAEContext _contexto;
        public PessoaService(SiCAEContext contexto)
        {
            _contexto = contexto;
        }

        public Pessoa BuscaPessoaID(int idPessoa)
        {
            return _contexto.Pessoa.Where(pessoa => pessoa.IdPessoa == idPessoa).SingleOrDefault();
        }

        public List<Pessoa> BuscarPessoas()
        {
            return _contexto.Pessoa.ToList();
        }

        public void InserirPessoa(Pessoa pessoa)
        {
            _contexto.Pessoa.Add(pessoa);
            _contexto.SaveChanges();
        }

        public void AlterarPessoa (Pessoa pessoa)
        {
            _contexto.Pessoa.Update(pessoa);
            _contexto.SaveChanges();

        }

        public void ExcluirPessoa(Pessoa pessoa)
        {
            _contexto.Pessoa.Remove(pessoa);
            _contexto.SaveChanges();
        }
    }
}
