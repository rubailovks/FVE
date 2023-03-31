using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVE.Domain.Models.OrderModel.OrderItemsModel.OrderItemPriceModel
{
    public class OrderItemPrice
    {
        public decimal Amount { get; set; }

        public decimal CatalogAmount { get; set; }

        public decimal? Bonus { get; set; }

        public decimal Vat { get; set; }
    }
}
