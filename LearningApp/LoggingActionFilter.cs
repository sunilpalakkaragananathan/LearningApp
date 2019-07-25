using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace LearningApp
{
    public class LoggingActionFilter : IActionFilter
    {
        ILogger _logger;

        public LoggingActionFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<LoggingActionFilter>();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //if (context.ActionArguments.ContainsKey("id"))
            //{
                
            //}
            _logger.LogInformation($"Action '{context.ActionDescriptor.DisplayName}' executing");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"Action '{context.ActionDescriptor.DisplayName}' executed");
        }


    }

    //public class LoggingActionFilter : IAsyncActionFilter
    //{
    //    public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    //    {
    //        //// execute any code before the action executes
    //        var result = await next();
    //        // execute any code after the action executes

    //    }
    //}
}
