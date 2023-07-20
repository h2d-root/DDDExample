
using DDDExample.Infrastructure;

namespace DDDExample.domain.Entity
{
    public class Product:BaseEntity, IEntity
    {
        public Guid CategoryId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stok { get; set; }
    }
}
