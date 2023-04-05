using FluentValidation;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using FVE.Domain.DomainServices;
using FVE.Domain.Models.OrderModel.OrderItemsModel;
using FVE.Domain.Validators.OrderValidators;
using FVE.Domain.Validators.OrderValidators.OrderItemsValidators;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace FVE.UnitTests
{
    public class OrderItemsValidatorUnitTests
    {
        private readonly IServiceScope _serviceScope;
        public OrderItemsValidatorUnitTests()
        {
            var serviceCollection = new ServiceCollection();
            _configureServiceCollection(serviceCollection);
            _serviceScope = serviceCollection.BuildServiceProvider().CreateScope();
        }
        [Fact]
        public async Task OrderItemsValidatorUnitTest()
        {
            var items = new List<OrderItem> { new() {BookId = 1 } };
            var validator = _serviceScope.ServiceProvider.GetRequiredService<OrderItemsValidator>();
            var validationResult  = await validator.TestValidateAsync(items, default);
            validationResult.ShouldHaveValidationErrorFor(x => x);
        }

        private void _configureServiceCollection(ServiceCollection services)
        {
            var mockOrderValidationDomainService = new Mock<IOrderValidationQueriesDomainService>();
            mockOrderValidationDomainService
                .Setup((x) => x.GetNotExistsItems(It.IsAny<IEnumerable<OrderItem>>(), default))
                .ReturnsAsync(new List<OrderItem>() { new() { BookId = 1 } });
            services.AddScoped(sp => mockOrderValidationDomainService.Object);

            var mockOrderItemValidator = new Mock<IValidator<OrderItem>>();
            mockOrderItemValidator
                .Setup(x => x.ValidateAsync(It.IsAny<OrderItem>(), default))
                .Returns(Task.FromResult(new ValidationResult()));
            services.AddTransient(sp => mockOrderItemValidator.Object);
            services.AddTransient<OrderItemsValidator>();
        }
    }
}