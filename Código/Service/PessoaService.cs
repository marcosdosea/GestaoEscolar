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

        public List<Pessoa> BuscarPessoas()
        {
            return _contexto.Pessoa.ToList();
        }

        public void InserirPessoa(Pessoa pessoa)
        {
            _contexto.Pessoa.Add(pessoa);
            _contexto.SaveChanges();
        }
    }
}
