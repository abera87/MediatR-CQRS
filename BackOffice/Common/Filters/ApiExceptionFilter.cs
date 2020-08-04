using System;
using System.Collections.Generic;
using BackOffice.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BackOffice.Common.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        private readonly Dictionary<Type, Action<ExceptionContext>> exceptionHandlers;

        public ApiExceptionFilter()
        {
            //Register known exception types and handlers
            exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>{
                {typeof(EntityValidationException), HandleEntityValidationException},
                {typeof(NotFoundException),HandleNotFoundException}
            };
        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);

            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();
            if (exceptionHandlers.ContainsKey(type))
            {
                exceptionHandlers[type].Invoke(context);
                return;
            }
            HandleUnknownException(context);
        }

        private void HandleUnknownException(ExceptionContext context)
        {
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An error occured while processing your request.",
                Type = "https://tools.ieif.org/html/rfc7321"
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }

        private void HandleNotFoundException(ExceptionContext context)
        {
            var exception = context.Exception as NotFoundException;

            var details = new ProblemDetails
            {
                Title = "The specificed resource was not found.",
                Type = "https://tools.ieif.org/html/rfc7321",
                Detail = exception.Message
            };

            context.Result = new NotFoundObjectResult(details);
            context.ExceptionHandled = true;
        }

        private void HandleEntityValidationException(ExceptionContext context)
        {
            var exception = context.Exception as EntityValidationException;
            var details = new ValidationProblemDetails(exception.Errors)
            {
                Type = "https://tools.ieif.org/html/rfc7321",
            };
            context.Result = new BadRequestObjectResult(details);
            context.ExceptionHandled = true;
        }
    }
}