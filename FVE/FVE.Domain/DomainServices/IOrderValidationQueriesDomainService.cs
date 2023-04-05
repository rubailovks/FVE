using FVE.Domain.Models.OrderModel.OrderItemsModel;

namespace FVE.Domain.DomainServices
{
    public interface IOrderValidationQueriesDomainService
    {
        Task<IEnumerable<OrderItem>> GetNotExistsItems(IEnumerable<OrderItem> items, CancellationToken cancellationToken);
    }
}
