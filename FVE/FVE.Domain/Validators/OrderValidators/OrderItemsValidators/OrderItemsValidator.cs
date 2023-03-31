﻿using FluentValidation;
using FVE.Domain.Models.OrderModel.OrderItemsModel;

namespace FVE.Domain.Validators.OrderValidators.OrderItemsValidators
{
    public class OrderItemsValidator : AbstractValidator<IEnumerable<OrderItem>>
    {
    }
}
