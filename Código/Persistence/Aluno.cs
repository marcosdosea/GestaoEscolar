﻿using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Aluno
    {
        public Aluno()
        {
            Alunopessoaresponsavel = new HashSet<Alunopessoaresponsavel>();
        }

        public int IdAluno { get; set; }
        public string NomeSocial { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Rua { get; set; }
        public string Cep { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
        public string ProcedenciaEscolar { get; set; }
        public string Nacionalidade { get; set; }
        public string Identidade { get; set; }
        public string Telefone { get; set; }
        public string Genero { get; set; }
        public string CertidaoNascimento { get; set; }
        public string CorRaca { get; set; }
        public string Sus { get; set; }
        public string Nis { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string NumeroImovel { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Alunopessoaresponsavel> Alunopessoaresponsavel { get; set; }
    }
}
