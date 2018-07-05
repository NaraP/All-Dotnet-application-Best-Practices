using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Utillity.ErrorLogs;

namespace COREWebAPICRUDApplication
{
    public class ExceptionLoggerFilter : ExceptionFilterAttribute
    {
        private static IErrorLogger _Logger = new ErrorLogger();

        public override void OnException(ExceptionContext actionExecutedContext)
        {
            base.OnException(actionExecutedContext);
            string exceptionMessage = string.Empty;
            string StackTrace = string.Empty;

            if (actionExecutedContext.Exception.InnerException == null)
            {
                exceptionMessage = actionExecutedContext.Exception.Message;
                StackTrace = actionExecutedContext.Exception.StackTrace;
            }
            else
            {
                exceptionMessage = actionExecutedContext.Exception.Message;
                StackTrace = actionExecutedContext.Exception.StackTrace;
            }
            //We can log this exception message to the file or database.  
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("An unhandled exception was thrown by service."),
                ReasonPhrase = "Internal Server Error.Please Contact your Administrator."
            };
            // actionExecutedContext.Response = response;

            _Logger.ExceptionHandler(actionExecutedContext.Exception, StackTrace, null);
            base.OnException(actionExecutedContext);
        }
    }
}
