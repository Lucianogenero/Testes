using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyCompany.Communication.Response.ResourceMessagesException;
using MyCompany.Communication.Response.ResponseErrors;
using MyCompany.Exceptions.ExceptionBase;

namespace MyCompany.Api.Filters
{
    public class ExceptionFiltersClass : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is MyCompanyExceptions myExceptions)
                HandleProjectException(myExceptions, context);
            else
                HandleUnknowException(context);
        }

        private static void HandleProjectException(MyCompanyExceptions myExceptions, ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)myExceptions.GetStatusCode();
            context.Result = new ObjectResult(new ResponseErrorJson(myExceptions.GetErrorMessage()));
        }

        private static void HandleUnknowException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorJson( ResourceMessageExceptions.EXCEPT_UNKCNOWN));
        }
    }
}
