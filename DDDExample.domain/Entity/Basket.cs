
using DDDExample.Infrastructure;

namespace DDDExample.domain.Entity
{
    public class Basket:BaseEntity, IEntity
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
    }
}
