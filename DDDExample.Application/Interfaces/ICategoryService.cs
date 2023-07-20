using DDDExample.domain.Entity;

namespace DDDExample.Application.Interfaces
{
    public interface ICategoryService
    {
        public bool Add(Category category);
        public bool Update(Category category);
        public bool Delete(Category category);
        public List<Category> GetAll();
    }
}
