using Microsoft.AspNetCore.Http;
using MicrosservicoExemplo.Application;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MicrosservicoExemplo.Infrastructure.Web.Middleware
{
    public class NotificationHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly INotificationContext _notificationContext;

        public NotificationHandlerMiddleware(RequestDelegate next, INotificationContext notificationContext)
        {
            _next = next;
            _notificationContext = notificationContext;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next.Invoke(context);

            if (_notificationContext.Invalid)
            {
                context.Response.Clear();
                context.Response.StatusCode = 422;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(_notificationContext.Notifications));
            }


        }

    }
}
