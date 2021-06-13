using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Pessoanotificacao
    {
        public int IdPessoa { get; set; }
        public int IdNotificacao { get; set; }

        public virtual Notificacao IdNotificacaoNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
