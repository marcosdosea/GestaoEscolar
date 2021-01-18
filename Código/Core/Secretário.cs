using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Secretário
    {
        public Secretário()
        {
            Diretor = new HashSet<Diretor>();
        }

        public int IdSecretário { get; set; }
        public int IdPessoa { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
        public virtual ICollection<Diretor> Diretor { get; set; }
    }
}
