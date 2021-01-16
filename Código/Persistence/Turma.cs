using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Turma
    {
        public int IdTurma { get; set; }
        public string NomeTurma { get; set; }
        public string Turno { get; set; }
        public int AnoDaTurma { get; set; }
        public byte IsActive { get; set; }
        public int IdEscola { get; set; }

        public virtual Escola IdEscolaNavigation { get; set; }
    }
}
