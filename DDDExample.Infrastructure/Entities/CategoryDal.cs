using DDDExample.domain.Entity;
using DDDExample.Infrastructure.EntityFramework;

namespace DDDExample.Infrastructure.Entities
{
    public class CategoryDal : efEntitiyRepositoryBase<Category, DDDExampleDBContext>, ICategoryDal
    {

    }
}
