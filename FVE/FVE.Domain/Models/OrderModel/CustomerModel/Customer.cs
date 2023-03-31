using FVE.Domain.Models.OrderModel.CustomerModel;

namespace FVE.Domain.Models.OrderModel.CustomerModel
{
    public class Customer
    {
        public Person Person { get; set; }

        public string Email { get; set; }
    }
}
