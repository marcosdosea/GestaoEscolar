using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Cidade
    {
        public Cidade()
        {
            Escola = new HashSet<Escola>();
        }

        public int CodIbge { get; set; }

        public virtual ICollection<Escola> Escola { get; set; }
    }
}
