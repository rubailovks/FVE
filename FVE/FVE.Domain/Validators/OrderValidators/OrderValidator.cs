using FluentValidation;
using FVE.Domain.Models.OrderModel;
using FVE.Domain.Validators.OrderValidators.CustomerValidators;

namespace FVE.Domain.Validators.OrderValidators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator(IValidator<CustomerValidator> customerValidator)
        {

        }
    }
}
