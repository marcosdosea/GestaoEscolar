using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Alunopessoaresponsavel
    {
        public int IdPessoa { get; set; }
        public string Parentesco { get; set; }
        public int IdAluno { get; set; }

        public virtual Aluno IdAlunoNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
