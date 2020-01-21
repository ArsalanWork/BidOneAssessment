using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BidOneAssessment.Infrastructure.Mediator
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger) => _logger = logger;

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var jsonDetails = JsonConvert.SerializeObject(request);
            _logger.LogInformation($"Handling GoalsGetter Command {typeof(TRequest).Name}");
            _logger.LogDebug($"DEBUG: Starting Command Details: {jsonDetails}");
            var response = await next();
            _logger.LogDebug($"DEBUG: Finished Command Details: {jsonDetails}");
            _logger.LogInformation($"Handled GoalsGetter Command {typeof(TRequest).Name}");
            return response;
        }
    }
}
