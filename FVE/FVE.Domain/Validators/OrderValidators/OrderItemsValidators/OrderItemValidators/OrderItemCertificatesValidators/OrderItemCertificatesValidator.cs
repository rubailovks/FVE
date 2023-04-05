using FluentValidation;
using FVE.Domain.Models.OrderModel.OrderItemsModel.OrderItemCertificateModel;

namespace FVE.Domain.Validators.OrderValidators.OrderItemsValidators.OrderItemValidators.OrderItemCertificatesValidators
{
    public class OrderItemCertificatesValidator : AbstractValidator<IEnumerable<OrderItemCertificate>>
    {
        public OrderItemCertificatesValidator(IValidator<OrderItemCertificate> certificateValidator)
        {
            RuleForEach(certificates => certificates)
                .SetValidator(certificateValidator);
        }
    }
}
