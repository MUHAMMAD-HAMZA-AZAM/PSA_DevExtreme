using API.App_Exceptions;
using API.Logging;
using Microsoft.AspNetCore.Mvc;

using Persistence.Database;
using Shared.Wrappers;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly ILoggerManager _loggerManager;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, ILoggerManager loggerManager)
        {
            _next = next;
            _logger = logger;
            _loggerManager = loggerManager;

        }
        public async Task Invoke(HttpContext context, IExceptionService exceptionService)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                Response _response = new Response();
                var response = context.Response;
                response.ContentType = "application/json";
                _response.Message = error.Message;
                _logger.LogError(error, error.Message);
                exceptionService.LogException(error);
                switch (error)
                {
                    case BadHttpRequestException e:
                        _response.StatusCode = Status.BadRequest;
                        break;
                    case UnauthorizedAccessException e:
                        _response.StatusCode = Status.UnAuthorized;
                        break;
                    case KeyNotFoundException e:
                        // not found error
                        _response.StatusCode = Status.NotFound;
                        break;
                    default:
                        // unhandled error
                        _response.StatusCode = Status.Failure;
                        break;
                }
                var result = JsonSerializer.Serialize(_response);
                await response.WriteAsync(result);
            }
        }
    }
}
