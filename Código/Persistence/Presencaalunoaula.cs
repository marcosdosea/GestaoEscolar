using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Presencaalunoaula
    {
        public int IdAula { get; set; }
        public int IdAluno { get; set; }
        public byte EstaPresente { get; set; }
    }
}
