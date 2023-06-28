using FluentValidation;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using FluentValidation.Validators;
using FVE.Domain.Models.OrderModel;
using FVE.Domain.Models.OrderModel.CustomerModel;
using FVE.Domain.Models.OrderModel.DeliveryModel;
using FVE.Domain.Models.OrderModel.OrderItemsModel;
using FVE.Domain.Validators.OrderValidators;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace FVE.UnitTests
{
    public class OrderTests
    {
        private readonly ServiceProvider _serviceProvider;
        public OrderTests()
        {
            var serviceCollection = new ServiceCollection();
            _configureServiceCollection(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        [Fact]
        public async Task OnlineOrderTestSuccessTest()
        {
            var order = new Order()
            {
                Customer = new() { },
                Delivery = new() { },
                OrderItems = new List<OrderItem>() { new() }
            };
            var validationResult = await _validator.TestValidateAsync(order, (options) =>
            {
                options.IncludeRuleSets(RuleSets.OnlineOrReserveOrderRuleSet).IncludeRulesNotInRuleSet();
            }, default);
            validationResult.ShouldNotHaveValidationErrorFor(x => x.Customer);
            validationResult.ShouldNotHaveValidationErrorFor(x => x.OrderItems);
            validationResult.ShouldNotHaveValidationErrorFor(x => x.Delivery);
        }

        [Fact]
        public async Task OnlineOrderTestErrorTest()
        {
            var order = new Order();
            var validationResult = await _validator.TestValidateAsync(order, (options) =>
            {
                options.IncludeRuleSets(RuleSets.OnlineOrReserveOrderRuleSet).IncludeRulesNotInRuleSet();
            }, default);

            validationResult.ShouldHaveValidationErrorFor(x => x.Customer).WithErrorCode("NotNullValidator");
            validationResult.ShouldHaveValidationErrorFor(x => x.OrderItems).WithErrorCode("NotEmptyValidator");
            validationResult.ShouldHaveValidationErrorFor(x => x.Delivery).WithErrorCode("NotNullValidator");
        }

        private AbstractValidator<Order> _validator => _serviceProvider.GetRequiredService<AbstractValidator<Order>>();

        private IValidator<T> getMockedValidator<T>()
        {
            var mock = new Mock<IValidator<T>>();
            mock.Setup(x => x.ValidateAsync(It.IsAny<T>(), default))
                .ReturnsAsync(new ValidationResult());
            return mock.Object;
        }
        private void _configureServiceCollection(ServiceCollection services)
        {
            services.AddTransient<AbstractValidator<Order>>(sp => new OrderValidator(
                getMockedValidator<Customer>(),
                getMockedValidator<Delivery>(),
                getMockedValidator<IEnumerable<OrderItem>>()
                ));
        }
    }
}
