using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Aula
    {
        public int IdAula { get; set; }
        public string Conteudo { get; set; }
        public DateTime Data { get; set; }
        public int IdProfessorTurmaDisciplina { get; set; }
    }
}
