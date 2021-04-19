using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolServerMain.Middleware
{
    public static class MiddlewareExtensions
    {
        /// <summary>
        ///     Регистрация мидлвары для обработки ошибок при выполнении запроса.
        /// </summary>
        /// <param name="builder"> Билдер приложения. </param>
        public static void UseHttpStatusCodeExceptionMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<HttpStatusCodeExceptionMiddleware>();
        }
    }
}
