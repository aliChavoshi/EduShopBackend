using Application.Common.BehavioursPipes;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class ConfigureService
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        //configure auto mapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //CQRS = Mediator
        //collection add => service provider get =>DI
        services.AddMediatR(Assembly.GetExecutingAssembly());
        //pipeline
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachedQueryBehaviour<,>));
    }
}