using FluentValidation.Results;
using FVE.Domain.Models.OrderModel;

namespace FVE.Domain.DomainServices
{
    public interface IOrderValidationDomainService
    {
        Task<ValidationResult> ValidateAsync(Order order, CancellationToken cancellationToken);
    }
}
