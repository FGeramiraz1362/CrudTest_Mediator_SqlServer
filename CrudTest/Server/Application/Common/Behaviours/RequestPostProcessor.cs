using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviours
{
    public class RequestPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        private readonly ILogger<RequestPostProcessor<TRequest, TResponse>> _logger;

        public RequestPostProcessor(ILogger<RequestPostProcessor<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            _logger.LogWarning($"Handled {typeof(TRequest)} with response {typeof(TResponse)}");
        }
    }
}
