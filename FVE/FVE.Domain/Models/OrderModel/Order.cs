using FVE.Domain.Models.OrderModel.CustomerModel;
using FVE.Domain.Models.OrderModel.DeliveryModel;
using FVE.Domain.Models.OrderModel.OrderItemsModel;

namespace FVE.Domain.Models.OrderModel
{
    public class Order
    {
        public OrderType OrderType { get; set; }
        public int Number { get; set; }
        public Customer Customer { get; set; }
        public Delivery Delivery { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }

    }
}
