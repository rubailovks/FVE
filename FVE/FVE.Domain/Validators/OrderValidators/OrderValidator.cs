using FluentValidation;
using FVE.Domain.Models.OrderModel;
using FVE.Domain.Models.OrderModel.CustomerModel;
using FVE.Domain.Models.OrderModel.DeliveryModel;
using FVE.Domain.Models.OrderModel.OrderItemsModel;
using FVE.Domain.Validators.OrderValidators.CustomerValidators;
using FVE.Domain.Validators.OrderValidators.DeliveryValidators;


namespace FVE.Domain.Validators.OrderValidators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator(
            IValidator<Customer> customerValidator,
            IValidator<Delivery> deliveryValidator,
            IValidator<IEnumerable<OrderItem>> orderItemsValidator
            )
        {
            RuleFor(o => o.Customer)
                .NotNull().WithMessage("Customer is required")
                .SetValidator(customerValidator);

            RuleFor(o => o.OrderItems)
                .NotEmpty().WithMessage("OrderItems is required")
                .SetValidator(orderItemsValidator);

            RuleSet(RuleSets.OnlineOrReserveOrderRuleSet, () =>
            {
                RuleFor(o => o.Delivery)
                .NotNull().WithMessage("Delivery is required")
                .SetValidator(deliveryValidator);
            });

        }
    }
}
