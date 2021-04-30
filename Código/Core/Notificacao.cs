using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Notificacao
    {
        public Notificacao()
        {
            Alunonotificacao = new HashSet<Alunonotificacao>();
            Pessoanotificacao = new HashSet<Pessoanotificacao>();
        }

        public int IdNotificacao { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Prioridade { get; set; }
        public string Remetente { get; set; }
        public byte? NotificaProfessor { get; set; }
        public byte? NotificaResponsavel { get; set; }
        public byte? NotificaAluno { get; set; }

        public virtual ICollection<Alunonotificacao> Alunonotificacao { get; set; }
        public virtual ICollection<Pessoanotificacao> Pessoanotificacao { get; set; }
    }
}
