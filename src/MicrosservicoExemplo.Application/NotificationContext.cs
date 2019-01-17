using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicrosservicoExemplo.Application
{
    public class NotificationContext : INotificationContext
    {
        private List<Notification> _notifications;

        public NotificationContext()
        {
            _notifications = new List<Notification>();
        }

        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public void AddNotifications(IEnumerable<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotification(string propriedade, string mensagem)
        {
            var notificacao = new Notification(propriedade, mensagem);
            AddNotification(notificacao);
        }

        public bool Valid => _notifications.Count == 0;
        public bool Invalid => !Valid;

        public IEnumerable<Notification> Notifications => _notifications.AsReadOnly();

    }
}
