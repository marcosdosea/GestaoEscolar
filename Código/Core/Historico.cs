using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Historico
    {
        public Historico()
        {
            Aluno = new HashSet<Aluno>();
        }

        public int IdHistorico { get; set; }
        public DateTime DataEmissao { get; set; }

        public virtual ICollection<Aluno> Aluno { get; set; }
    }
}
