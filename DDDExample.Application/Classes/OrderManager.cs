using DDDExample.Application.Interfaces;
using DDDExample.domain.Entity;
using DDDExample.Infrastructure.Entities;

namespace DDDExample.Application.Classes
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public List<Order> GetMyOrders(Guid userId)
        {
            var result = _orderDal.GetAll(o => o.UserId == userId);
            return result;
        }
    }
}
