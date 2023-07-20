using DDDExample.Infrastructure;

namespace DDDExample.domain.Entity
{
    public class Category:BaseEntity, IEntity
    {
        public string CategoryName { get; set; }
    }
}
