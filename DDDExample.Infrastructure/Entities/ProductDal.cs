using DDDExample.Infrastructure.EntityFramework;
using DDDExample.domain.Entity;
using DDDExample.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDExample.Infrastructure.Entities
{
    public class ProductDal : efEntitiyRepositoryBase<Product, DDDExampleDBContext>, IProductDal
    {
    }
}
