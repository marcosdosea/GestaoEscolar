using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class TurmaDTO
    {
        public int IdTurma { get; set; }
        public string NomeTurma { get; set; }
        public string Turno { get; set; }
        public int AnoDaTurma { get; set; }
        public byte IsActive { get; set; }
        public int IdEscola { get; set; }

        public virtual Escola IdEscolaNavigation { get; set; }
        public virtual ICollection<TurmaAluno> TurmaAluno { get; set; }
    }
}
