using FluentValidation;
using FVE.Domain.Models.OrderModel.OrderItemsModel.OrderItemPriceModel;
using FVE.Domain.Validators.Extensions;

namespace FVE.Domain.Validators.OrderValidators.OrderPrice
{
    public class OrderPriceValidator : AbstractValidator<OrderItemPrice>
    {
        public static decimal[] ALLOWED_VAT_VALUES = new[] { 10M, 13M, 20M };
        public OrderPriceValidator()
        {
            RuleFor(price => price.Vat).MustContainsInList(ALLOWED_VAT_VALUES);
        }   
        
    }
}
