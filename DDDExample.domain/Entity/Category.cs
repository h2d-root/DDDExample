using DDDExample.Infrastructure;

namespace DDDExample.domain.Entity
{
    public class Category:BaseEntity, IEntity
    {

        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
