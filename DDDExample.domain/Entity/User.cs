using DDDExample.Infrastructure;

namespace DDDExample.domain.Entity
{

    public class User:BaseEntity, IEntity
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
