using FVE.Domain.Models.OrderModel.OrderItemsModel;

namespace FVE.Domain.DomainServices
{
    public class OrderValidationQueriesDomainService:IOrderValidationQueriesDomainService
    {
        public Task<IEnumerable<OrderItem>> GetNotExistsItems(IEnumerable<OrderItem> items,CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
