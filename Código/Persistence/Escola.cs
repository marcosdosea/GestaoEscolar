using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Escola
    {
        public Escola()
        {
            Turma = new HashSet<Turma>();
        }

        public int IdEscola { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Rua { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public int IdDiretor { get; set; }
        public int CodIbge { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string NumeroImovel { get; set; }

        public virtual Cidade CodIbgeNavigation { get; set; }
        public virtual Diretor IdDiretorNavigation { get; set; }
        public virtual ICollection<Turma> Turma { get; set; }
    }
}
