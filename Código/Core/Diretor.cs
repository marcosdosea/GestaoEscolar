using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Diretor
    {
        public int IdDiretor { get; set; }
        public int IdSecretário { get; set; }
        public int IdPessoa { get; set; }

        public virtual Secretário Id { get; set; }
    }
}
