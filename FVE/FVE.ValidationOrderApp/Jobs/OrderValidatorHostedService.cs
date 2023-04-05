using FVE.Domain.DomainServices;
using FVE.Domain.Models.OrderModel;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace FVE.ValidationOrderApp.Jobs
{
    public class OrderValidatorHostedService : IHostedService
    {
        private readonly IOrderValidationDomainService _orderValidationDomainService;
        private readonly CancellationTokenSource _cts;
        ILogger<OrderValidatorHostedService> _logger;
        public OrderValidatorHostedService(IOrderValidationDomainService orderValidationDomainService, CancellationTokenSource cts, ILogger<OrderValidatorHostedService> logger)
        {
            _cts = cts;
            _orderValidationDomainService = orderValidationDomainService;
            _logger = logger;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Enter order number from Examples folder");
            var orderNumber = Console.ReadLine();
            var orderPath = Path.Combine(Environment.CurrentDirectory, "Examples", $"{orderNumber}.json");
            if (File.Exists(orderPath) is not true)
            {
                _logger.LogError("Invalid order number");
                _cts.Cancel();
                return;
            }
            var json = File.ReadAllText(orderPath);
            try
            {
                var order = JsonSerializer.Deserialize<Order>(json,new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                var validationResult = await _orderValidationDomainService.ValidateAsync(order, cancellationToken);

                Console.WriteLine("Order is valid: {0}", validationResult.IsValid);
                if (validationResult.IsValid is not true)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Errors:{0}{1}", Environment.NewLine, string.Join(Environment.NewLine, validationResult.Errors));
                    Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                _logger.LogError("Invalid json : {0}", ex.Message);
                _cts.Cancel();

            }
            _cts.Cancel();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Good bye");
            await Task.Delay(100);
        }
    }
}
