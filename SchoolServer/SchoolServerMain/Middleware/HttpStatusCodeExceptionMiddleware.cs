using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SchoolServerMain.Middleware
{
    /// <summary>
    ///     Мидлвара для обработки ошибок при выполнении запроса.
    /// </summary>
    [UsedImplicitly]
    public class HttpStatusCodeExceptionMiddleware
    {
        /// <summary>
        /// Делегат запроса.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Логгер.
        /// </summary>
        private readonly RequestDelegate _next;

        /// <summary>
        ///     Конструктор.
        /// </summary>
        public HttpStatusCodeExceptionMiddleware(RequestDelegate next,
            ILogger<HttpStatusCodeExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        ///     Метод выполнения мидлвары.
        /// </summary>
        /// <param name="httpContext"> Контекст запроса. </param>
        /// <returns> Таск. </returns>
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }         
            // Сюда писать catch
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Ошибка при выполнении запроса: {exception.Message}");
                await WriteResponse(httpContext, exception.Message);
            }
        }

        /// <summary>
        ///     Записывает ответ указанного контекста.
        /// </summary>
        /// <param name="context">Контекст запроса.</param>
        /// <param name="statusCode">Код ответа.</param>
        /// <param name="contentType"> Тип содержимого. </param>
        /// <param name="message">Сообщение ответа.</param>
        private static async Task WriteResponse(HttpContext context,
            string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
            string contentType = "text/plain; charset=utf-8")
        {
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = contentType;
            await context.Response.WriteAsync(message);
        }
    }
}
