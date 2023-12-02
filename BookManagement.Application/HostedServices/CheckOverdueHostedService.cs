using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using BookManagement.Domain.Interfaces;

namespace BookManagement.Application.HostedServices;

public class CheckNotReturnedBorrowsHostedService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    private const int HOUR_IN_MILLISECONDS = 3600000;

    private Timer _timer;

    public CheckNotReturnedBorrowsHostedService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(Check, null, 0, HOUR_IN_MILLISECONDS);

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Application is finished");

        return Task.CompletedTask;
    }

    private async void Check(object? state)
    {
        using var scope = _serviceProvider.CreateScope();

        var borrowRepository = scope.ServiceProvider.GetService<IBorrowRepository>();

        var notReturnedBorrows = await borrowRepository.GetNotReturnedBorrowsAsync();

        foreach (var borrow in notReturnedBorrows)
            Console.WriteLine($"Borrow Not Returned Id: {borrow.Id}");
    }
}