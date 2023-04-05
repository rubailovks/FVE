using FluentValidation;
using FVE.Domain.Models.OrderModel.OrderItemsModel;
using FVE.Domain.Models.OrderModel.OrderItemsModel.OrderItemCertificateModel;

namespace FVE.Domain.Validators.OrderValidators.OrderItemsValidators.OrderItemValidators
{
    public class OrderItemValidator : AbstractValidator<OrderItem>
    {
        private const int MAX_BOOKID_LENGTH = 100;
        public OrderItemValidator(IValidator<IEnumerable<OrderItemCertificate>> orderItemCertificatesValidator)
        {
            RuleFor(orderItem => orderItem.BookId)
                .GreaterThan(MAX_BOOKID_LENGTH).WithMessage((orderItem) => $@"BookId {orderItem.BookId} greather then {MAX_BOOKID_LENGTH}");

            RuleSet(RuleSets.EpcRuleSet, () =>
            {
                RuleFor(orderItem => orderItem.OrderItemCertificates)
                .NotNull().WithMessage("Certificates is required")
                .SetValidator(orderItemCertificatesValidator);
            });
        }
    }
}
