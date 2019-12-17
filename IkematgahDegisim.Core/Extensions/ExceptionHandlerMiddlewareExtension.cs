using IkematgahDegisim.Core.Utilities.Handlers._Exception;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Core.Extensions
{
    public static class ExceptionHandlerMiddlewareExtension
    {
        public static void ConfigureToCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
