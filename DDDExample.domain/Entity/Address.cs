using DDDExample.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDExample.domain.Entity
{
    public class Address:BaseEntity, IEntity
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}
