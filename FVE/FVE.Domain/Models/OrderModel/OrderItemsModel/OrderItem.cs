using FVE.Domain.Models.OrderModel.OrderItemsModel.OrderItemPriceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVE.Domain.Models.OrderModel.OrderItemsModel
{
    public class OrderItem
    {
        public int BookId { get; set; }

        public OrderItemPrice OrderItemPrice { get; set; }
    }
}
