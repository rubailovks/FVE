using FluentValidation;
using FVE.Domain.Models.OrderModel.OrderItemsModel.OrderItemCertificateModel;

namespace FVE.Domain.Validators.OrderValidators.OrderItemsValidators.OrderItemValidators.OrderItemCertificatesValidators.OrderItemCertificateValidator
{
    public class OrderItemCertificateValidator : AbstractValidator<OrderItemCertificate>
    {
        public OrderItemCertificateValidator()
        {
            RuleFor(certificate => certificate)
                .Must(c => c.Id.StartsWith("123")).WithMessage((certificate) => $"Certificate {certificate.Id} must starts with '123'");
        }
    }
}
