using DDDExample.Infrastructure;
using DDDExample.domain.Entity;

namespace DDDExample.Infrastructure.Entities
{
    public interface IUserDal : IEntityRepository<User> { }
}
