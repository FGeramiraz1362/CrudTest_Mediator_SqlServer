﻿using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviours
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TResponse : class
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                var response = await next();
                return response;
            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occurred!!");
                _logger.LogError(e, e.Message);
                return default;
            }


        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                var response = next();
                return response;
            }
            catch (Exception e)
            {
                _logger.LogError("Exception Occurred!!");
                _logger.LogError(e, e.Message);
                return default;
            }
        }
    }
}

