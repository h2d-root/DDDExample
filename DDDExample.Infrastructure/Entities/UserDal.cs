using DDDExample.Infrastructure.EntityFramework;
using DDDExample.domain.Entity;
using DDDExample.Infrastructure.EntityFramework;

namespace DDDExample.Infrastructure.Entities
{
    public class UserDal : efEntitiyRepositoryBase<User, DDDExampleDBContext>, IUserDal { }
}
