using DDDExample.Infrastructure;

namespace DDDExample.domain.Entity
{
    public class Order:BaseEntity,IEntity
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
