using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Diahoraprofessorturmadisciplina
    {
        public int IdProfessorTurmaDisciplina { get; set; }
        public int IdDiaHora { get; set; }

        public virtual Diahora IdDiaHoraNavigation { get; set; }
        public virtual Professorturmadisciplina IdProfessorTurmaDisciplinaNavigation { get; set; }
    }
}
