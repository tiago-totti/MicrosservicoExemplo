using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MicrosservicoExemplo.Application;

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
            
            if (_notificationContext.Invalid)
            {
                context.Result = new UnprocessableEntityObjectResult(_notificationContext.Notifications);
            }

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
