using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Turma
    {
        public Turma()
        {
            TurmaAluno = new HashSet<TurmaAluno>();
        }

        public int IdTurma { get; set; }
        public string NomeTurma { get; set; }
        public string Turno { get; set; }
        public int AnoDaTurma { get; set; }
        public byte IsActive { get; set; }
        public int EscolaIdEscola { get; set; }

        public virtual Escola EscolaIdEscolaNavigation { get; set; }
        public virtual ICollection<TurmaAluno> TurmaAluno { get; set; }
    }
}
