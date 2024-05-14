using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviours
{
    public class RequestPreProcessor<TRequest, TResponse> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger<RequestPreProcessor<TRequest, TResponse>> _logger;

        public RequestPreProcessor(ILogger<RequestPreProcessor<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            _logger.LogWarning($"Handling {typeof(TRequest)} Request");
        }
    }
}

