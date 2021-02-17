using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Service;

namespace Service
{
    public class NotificacaoService : INotificacaoService
    {
        private readonly SiCAEContext _contexto;

        public NotificacaoService(SiCAEContext contexto)
        {
            _contexto = contexto;
        }

        public List<Notificacao> BuscarNotificacoes()
        {
            return _contexto.Notificacao.ToList();
        }

        public Notificacao BuscarNotificacaoId(int Id)
        {
            return _contexto.Notificacao.Where(notificacao => notificacao.idNotificacao == Id).SingleOrDefault();
           
        }

        public void ExcluirNotificacao(Notificacao notificacao)
        {
            _contexto.Notificacao.Remove(notificacao);
            _contexto.SaveChanges();
        }

        public void InserirNotificacao(Notificacao notificacao)
        { 
                _contexto.Notificacao.Add(notificacao);
                _contexto.SaveChanges();
        }

    }
}
