using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Aula
    {
        public Aula()
        {
            Presencaalunoaula = new HashSet<Presencaalunoaula>();
        }

        public int IdAula { get; set; }
        public string Conteudo { get; set; }
        public DateTime Data { get; set; }
        public int IdProfessorTurmaDisciplina { get; set; }

        public virtual ICollection<Presencaalunoaula> Presencaalunoaula { get; set; }
    }
}
