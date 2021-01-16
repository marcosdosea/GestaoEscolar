using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Diretor
    {
        public Diretor()
        {
            Escola = new HashSet<Escola>();
        }

        public int IdDiretor { get; set; }
        public int IdSecretário { get; set; }
        public int IdPessoa { get; set; }

        public virtual Secretário Id { get; set; }
        public virtual ICollection<Escola> Escola { get; set; }
    }
}
