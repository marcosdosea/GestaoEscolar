using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Disciplina
    {
        public Disciplina()
        {
            Professorturmadisciplina = new HashSet<Professorturmadisciplina>();
        }

        public int IdDisciplina { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Professorturmadisciplina> Professorturmadisciplina { get; set; }
    }
}
