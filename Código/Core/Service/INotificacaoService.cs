using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface INotificacaoService
    {
        List<Notificacao>BuscarNotificacoes();

        Notificacao BuscarNotificacaoId(int IdNotificacao);
        void ExcluirNotificacao(Notificacao notificacao);

        void InserirNotificacao(Notificacao notificacao);

        void AlterarNotificacao(Notificacao notificacao);
    }
}
