
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace LearningApp
{
    public class LogFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
           var logtext = Log("OnActionExecuting ", context.RouteData);
            context.HttpContext.Response.WriteAsync(logtext);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var logtext = Log("OnActionExecuted ", context.RouteData);
            context.HttpContext.Response.WriteAsync(logtext);
        }

        //public override void OnResultExecuting(ResultExecutingContext context)
        //{
        //    var logtext = Log("OnResultExecuting ", context.RouteData);
        //    context.HttpContext.Response.WriteAsync(logtext);
        //}

        //public override void OnResultExecuted(ResultExecutedContext context)
        //{
        //    var logtext = Log("OnResultExecuted ", context.RouteData);
        //    context.HttpContext.Response.WriteAsync(logtext);
        //}

        private string Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            return $"{methodName}- controller:{controllerName} action:{actionName} \n";
        }
    }
}
