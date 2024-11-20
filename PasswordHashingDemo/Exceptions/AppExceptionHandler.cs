using Microsoft.AspNetCore.Diagnostics;
using PasswordHashingDemo.Models;
using System.ComponentModel.DataAnnotations;

namespace PasswordHashingDemo.Exceptions
{
    public class AppExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var response = new Response();

            if(exception is UserNotFoundException)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.Message = exception.Message;
                response.Title = "Invalid Username and Password";
            }
            else if(exception is ValidationException)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.Message = exception.Message;
                response.Title = "Invalid Inputs";
            }
            else
            {
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.Message = exception.Message;
                response.Title = "Something went wrong";
            }

            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            return true;
        }
    }
}
