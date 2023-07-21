using DDDExample.domain.Entity;

namespace DDDExample.Application.Interfaces
{
    public interface IOrderService
    {
        public List<Order> GetMyOrders(Guid userId);
    }
}
