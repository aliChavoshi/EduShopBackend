using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Common.BehavioursPipes;

public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TRequest> _logger;
    private readonly Stopwatch _timer;

    public PerformanceBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
        _timer = new Stopwatch();
    }


    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Performance (3. for Command) (4. for query)"); // temprory

        _timer.Start();

        var response = await next();

        _timer.Stop();

        var elapsedMilliseconds = _timer.ElapsedMilliseconds;

        if (elapsedMilliseconds <= 500) return response;

        var requestName = typeof(TRequest).Name;
        // var userId = _currentUserService.UserId;
        // var phoneNumber = _currentUserService.PhoneNumber;

        _logger.LogWarning(
            "CleanArchitecture Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} ",
            requestName, elapsedMilliseconds, request);

        return response;
    }
}