using FVE.Domain.Models.OrderModel.OrderItemsModel;
using FVE.Infrastructure.Queries;

namespace FVE.Domain.DomainServices
{
    public class OrderValidationQueriesDomainService:IOrderValidationQueriesDomainService
    {
        private readonly IOrderItemsQueries _orderItemsQueries;
        public OrderValidationQueriesDomainService(IOrderItemsQueries orderItemsQueries)
        {
            _orderItemsQueries = orderItemsQueries;
        }
        public async Task<IEnumerable<OrderItem>> GetNotExistsItems(IEnumerable<OrderItem> items,CancellationToken cancellationToken)
        {
            var notExistsItemIds = await _orderItemsQueries.GetNotExistsItemNumbers(items.Select(x=>x.BookId));
            return items.Where(x => notExistsItemIds.Contains(x.BookId));
        }
    }
}
