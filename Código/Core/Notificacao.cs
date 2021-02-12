using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Notificacao
    {
        public int idNotificacao { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public string prioridade { get; set; }
        public string remetente { get; set; }
        public string destinatario { get; set; }


    }
}
