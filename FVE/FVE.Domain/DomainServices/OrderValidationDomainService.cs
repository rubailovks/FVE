using FluentValidation;
using FluentValidation.Results;
using FVE.Domain.Models.OrderModel;
using FVE.Domain.Validators.OrderValidators;

namespace FVE.Domain.DomainServices
{
    public class OrderValidationDomainService : IOrderValidationDomainService
    {
        private readonly IValidator<Order> _orderValidator;
        public OrderValidationDomainService(IValidator<Order> orderValidator)
        {
            _orderValidator = orderValidator;
        }

        public async Task<ValidationResult> ValidateAsync(Order order, CancellationToken cancellationToken)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));

            switch (order.OrderType)
            {
                case OrderType.Online:
                case OrderType.Reservation:
                    return await _orderValidator.ValidateAsync(order, options: (options) =>
                    {
                        options.IncludeRuleSets(RuleSets.OnlineOrReserveOrderRuleSet).IncludeRulesNotInRuleSet();
                    }, cancellationToken);

                case OrderType.EPC:

                    return await _orderValidator.ValidateAsync(order, options: (options) =>
                    {
                        options.IncludeRuleSets(RuleSets.EpcRuleSet).IncludeRulesNotInRuleSet();
                    },cancellationToken);

                default: throw new ArgumentOutOfRangeException(nameof(order.OrderType));
            }
        }
    }
}
