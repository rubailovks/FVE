// See https://aka.ms/new-console-template for more information

using FluentValidation;
using FVE.Domain.DomainServices;
using FVE.Domain.Validators.OrderValidators;
using FVE.ValidationOrderApp.Jobs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading;

var cts = new CancellationTokenSource();

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton(cts);
        services.AddTransient<IOrderValidationDomainService, OrderValidationDomainService>();
        services.AddValidatorsFromAssemblyContaining<OrderValidator>(ServiceLifetime.Transient);
        services.AddHostedService<OrderValidatorHostedService>();
    })
    .Build();

await host.RunAsync(cts.Token);
