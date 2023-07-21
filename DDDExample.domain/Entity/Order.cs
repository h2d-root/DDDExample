using DDDExample.Infrastructure;

namespace DDDExample.domain.Entity
{
    public class Order:BaseEntity,IEntity
    {
        public Guid UserId { get; set; }
        public string State { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
