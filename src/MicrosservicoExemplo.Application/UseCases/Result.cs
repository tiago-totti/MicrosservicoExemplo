using Flunt.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace MicrosservicoExemplo.Application.UseCases
{
    public class Resultado
    {

        protected Resultado()
            : this(new List<Notification>())
        {
        }

        protected Resultado(IEnumerable<Notification> notificacoes)
        {
            Notificacoes = notificacoes;
        }

        public bool Valido => Notificacoes.Count() == 0;

        public IEnumerable<Notification> Notificacoes { get; private set; }

     
    }
}
