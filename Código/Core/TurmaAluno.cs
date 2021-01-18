using System;
using System.Collections.Generic;

namespace Core
{
    public partial class TurmaAluno
    {
        public int IdTurma { get; set; }
        public int IdAluno { get; set; }

        public virtual Aluno IdAlunoNavigation { get; set; }
        public virtual Turma IdTurmaNavigation { get; set; }
    }
}
