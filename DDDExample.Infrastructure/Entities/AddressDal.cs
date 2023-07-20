using DDDExample.domain.Entity;
using DDDExample.Infrastructure.EntityFramework;

namespace DDDExample.Infrastructure.Entities
{
    public class AddressDal : efEntitiyRepositoryBase<Address, DDDExampleDBContext>, IAddressDal
    {

    }
}
