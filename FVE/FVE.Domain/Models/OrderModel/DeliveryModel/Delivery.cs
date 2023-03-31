using FVE.Domain.Models.OrderModel.DeliveryModel;

namespace FVE.Domain.Models.OrderModel.DeliveryModel
{
    public class Delivery
    {
        public int DeliveryType { get; set; }

        public DeliveryAddress DeliveryAddress { get; set; }
    }
}
