using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Avaliacao
    {
        public int IdAvaliacao { get; set; }
        public int Peso { get; set; }
        public int IdAluno { get; set; }
        public int IdProfessorTurmaDisciplina { get; set; }
        public decimal Nota { get; set; }

        public virtual Aluno IdAlunoNavigation { get; set; }
    }
}
