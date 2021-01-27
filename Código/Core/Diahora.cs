using Org.BouncyCastle.Asn1.Cms;
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
        public TimeSpan HorarioInicio { get; set; }
        
        public TimeSpan HorarioTermino { get; set; }
        public string DiaSemana { get; set; }

        public virtual ICollection<Diahoraprofessorturmadisciplina> Diahoraprofessorturmadisciplina { get; set; }
    }
}
