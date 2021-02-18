using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Alunopessoaresponsavel = new HashSet<Alunopessoaresponsavel>();
            Escola = new HashSet<Escola>();
        }

        public int IdPessoa { get; set; }
        public string NomeSocial { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Rua { get; set; }
        public string Cep { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
        public string Profissao { get; set; }
        public string Nacionalidade { get; set; }
        public string Identidade { get; set; }
        public string Telefone { get; set; }
        public string Sexo { get; set; }
        public string CorRaca { get; set; }
        public string Complemento { get; set; }
        public string NumeroImovel { get; set; }
        public string Bairro { get; set; }
        public string TipoPessoa { get; set; } 

        public virtual ICollection<Alunopessoaresponsavel> Alunopessoaresponsavel { get; set; }
        public virtual ICollection<Escola> Escola { get; set; }
    }

  
}
