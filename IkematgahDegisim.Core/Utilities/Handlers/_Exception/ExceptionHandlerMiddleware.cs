using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IkematgahDegisim.Core.Utilities.Handlers._Exception
{
    public class ExceptionHandlerMiddleware
    {
        private RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate _next)
        {
            this._next = _next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }

            catch (ValidationException exception)
            {
                await HandleValidationExceptionAsync(context, exception);

            }


            catch (SecurityTokenExpiredException tokenExpiredException)
            {
                await HandleTokenExpiredExceptionAsync(context, tokenExpiredException);
            }

            catch (SqlException sqlException)
            {
                await HandleSqlExceptionAsync(context, sqlException);
            }



        }

        private Task HandleSqlExceptionAsync(HttpContext context, Exception exception)
        {

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "Internal Server Error";
            if (exception.GetType() == typeof(SqlException))
            {
                message = exception.Message;
            }

            return context.Response.WriteAsync(new Error()
            {
                error = new ErrorDetails
                {
                    code = context.Response.StatusCode,
                    message = message,

                }
            }.ToString());
        }

        private Task HandleTokenExpiredExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

            string message = "UnAuthorized";

            if (exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                message = exception.Message;
            }

            return context.Response.WriteAsync(new Error()
            {
                error = new AuthenticateErrorDetails
                {
                    code = context.Response.StatusCode,
                    message = message,
                    isTokenExpired = true

                }
            }.ToString());
        }


        private Task HandleValidationExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "Internal Server Error";
            if (exception.GetType() == typeof(ValidationException))
            {
                message = exception.Message;
            }

            return context.Response.WriteAsync(new Error()
            {
                error = new ErrorDetails
                {
                    code = context.Response.StatusCode,
                    message = message
                }
            }.ToString());
        }
    }
}

