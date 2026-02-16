using Microsoft.Extensions.DependencyInjection;

namespace Hospital_management_system.Application.Common;

public class Mediator : IMediator
{
    private readonly IServiceProvider _serviceProvider;

    public Mediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        var requestType = request.GetType();
        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(requestType, typeof(TResponse));

        var handler = _serviceProvider.GetRequiredService(handlerType);
        
        // Use reflection to call HandleAsync since we don't know the exact types at compile time here
        var method = handlerType.GetMethod("HandleAsync");
        if (method == null) throw new InvalidOperationException($"HandleAsync method not found on {handlerType.Name}");

        var result = method.Invoke(handler, new object[] { request, cancellationToken });
        return await (Task<TResponse>)result!;
    }
}
