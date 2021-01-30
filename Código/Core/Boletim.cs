using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Boletim
    {
        public int IdBoletim { get; set; }
        public int Ano { get; set; }
        public int IdAluno { get; set; }

        public virtual Aluno IdAlunoNavigation { get; set; }
    }
}
