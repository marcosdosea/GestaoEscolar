using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Diahoraprofessorturmadisciplina
    {
        public int IdDiaHora { get; set; }
        public int IdProfessorTurmaDisciplina { get; set; }

        public virtual Diahora IdDiaHoraNavigation { get; set; }
    }
}
