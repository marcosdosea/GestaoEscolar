using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Aula
    {
        public Aula()
        {
            Alunoaula = new HashSet<Alunoaula>();
        }

        public int IdAula { get; set; }
        public string Conteudo { get; set; }
        public DateTime Data { get; set; }
        public int IdProfessorTurmaDisciplina { get; set; }

        public virtual Professorturmadisciplina IdProfessorTurmaDisciplinaNavigation { get; set; }
        public virtual ICollection<Alunoaula> Alunoaula { get; set; }
    }
}
