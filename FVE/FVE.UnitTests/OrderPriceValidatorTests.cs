using FVE.Domain.Models.OrderModel.OrderItemsModel.OrderItemPriceModel;
using FVE.Domain.Validators.OrderValidators.OrderPrice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.TestHelper;

namespace FVE.UnitTests
{
    public class OrderPriceValidatorTests
    {
        private readonly OrderPriceValidator _validator;
        public OrderPriceValidatorTests()
        {
            _validator = new();
        }
        [Theory]
        [MemberData(nameof(AllowedVatData))]
        public async Task OrderPriceValidatorVatSuccessTest(decimal vat)
        {
            var orderPrice = new OrderItemPrice() { Vat = vat };
            (await _validator.TestValidateAsync(orderPrice, options: (options) =>
            {
                options.IncludeProperties(x => x.Vat);
            }))
                .ShouldNotHaveValidationErrorFor(x => x.Vat);
        }
        [Fact]
        public async Task OrderPriceValidatorVatErrorTest()
        {
            var invalidVatValue = 999;
            var orderPrice = new OrderItemPrice() { Vat = invalidVatValue };
            (await _validator.TestValidateAsync(orderPrice, options: (options) =>
            {
                options.IncludeProperties(x => x.Vat);
            }))
                .ShouldHaveValidationErrorFor(x => x.Vat);
        }


        public static IEnumerable<object[]> AllowedVatData()
        {
            var data = new List<object[]> { };
            foreach (var vat in OrderPriceValidator.ALLOWED_VAT_VALUES)
            {
                data.Add(new object[] { vat });
            }
            return data;
        }

    }
}
