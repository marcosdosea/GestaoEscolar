using System;
using System.Collections.Generic;

namespace Core
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
