using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Professor
    {
        public int IdProfessor { get; set; }
        public int IdPessoa { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
