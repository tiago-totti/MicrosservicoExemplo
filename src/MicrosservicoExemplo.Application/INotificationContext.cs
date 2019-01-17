using System.Collections.Generic;
using Flunt.Notifications;

namespace MicrosservicoExemplo.Application
{
    public interface INotificationContext
    {
        bool Invalid { get; }
        bool Valid { get; }
        IEnumerable<Notification> Notifications { get; }

        void AddNotification(Notification notification);
        void AddNotification(string propriedade, string mensagem);
        void AddNotifications(IEnumerable<Notification> notifications);
    }
}