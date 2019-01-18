using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MicrosservicoExemplo.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicrosservicoExemplo.Infrastructure.Web.Filters
{
    public class NotificationHandlerFilter : IActionFilter
    {
        private readonly INotificationContext _notificationContext;

        public NotificationHandlerFilter(INotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

            ; // var notificationContext = context. .GetService<INotificationContext>();

            if (_notificationContext.Invalid)
            {
                context.Result = new UnprocessableEntityObjectResult(_notificationContext.Notifications);
                //await context.Response.WriteAsync(JsonConvert.SerializeObject());
            }

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
