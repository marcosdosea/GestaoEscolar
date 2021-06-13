using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Alunonotificacao
    {
        public int IdAluno { get; set; }
        public int IdNotificacao { get; set; }

        public virtual Aluno IdAlunoNavigation { get; set; }
        public virtual Notificacao IdNotificacaoNavigation { get; set; }
    }
}
