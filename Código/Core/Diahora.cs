using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Diahora
    {
        public Diahora()
        {
            Diahoraprofessorturmadisciplina = new HashSet<Diahoraprofessorturmadisciplina>();
        }

        public int IdDiaHora { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioTermino { get; set; }
        public string DiaSemana { get; set; }

        public virtual ICollection<Diahoraprofessorturmadisciplina> Diahoraprofessorturmadisciplina { get; set; }
    }
}
