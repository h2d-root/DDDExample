using DDDExample.Infrastructure.EntityFramework;
using DDDExample.domain.Entity;
using DDDExample.Infrastructure;

namespace DDDExample.Infrastructure.Entities
{
    public class OrderDal : efEntitiyRepositoryBase<Order, DDDExampleDBContext>, IOrderDal { }
}
