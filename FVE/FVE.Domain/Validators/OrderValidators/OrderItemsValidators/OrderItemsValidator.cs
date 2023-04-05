using FluentValidation;
using FVE.Domain.DomainServices;
using FVE.Domain.Models.OrderModel.OrderItemsModel;

namespace FVE.Domain.Validators.OrderValidators.OrderItemsValidators
{
    public class OrderItemsValidator : AbstractValidator<IEnumerable<OrderItem>>
    {
        public OrderItemsValidator(IOrderValidationQueriesDomainService queriesDomainService, IValidator<OrderItem> orderItemValidator)
        {

            RuleFor(items => items).CustomAsync(async (orderItems,ctx,cancellationToken) =>
            {
                var notExistItems = await queriesDomainService.GetNotExistsItems(orderItems, cancellationToken);
                if (notExistItems.Any())
                {
                    ctx.AddFailure($"Items {string.Join(',', notExistItems.Select(x => x.BookId))} not found;");
                }
            });
            RuleForEach(orderItem => orderItem)
                .SetValidator(orderItemValidator);
        }
    }
}
