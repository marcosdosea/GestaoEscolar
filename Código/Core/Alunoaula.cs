using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Alunoaula
    {
        public int IdAula { get; set; }
        public byte EstaPresente { get; set; }
        public int IdAluno { get; set; }

        public virtual Aluno IdAlunoNavigation { get; set; }
        public virtual Aula IdAulaNavigation { get; set; }
    }
}
