using DDDExample.domain.Entity;
using DDDExample.Infrastructure.EntityFramework;

namespace DDDExample.Infrastructure.Entities
{
    public class BasketDal : efEntitiyRepositoryBase<Basket, DDDExampleDBContext>, IBasketDal { }
}
