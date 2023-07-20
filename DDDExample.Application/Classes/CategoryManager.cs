using DDDExample.Application.Interfaces;
using DDDExample.domain.Entity;
using DDDExample.Infrastructure.Entities;

namespace DDDExample.Application.Classes
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public bool Add(Category category)
        {
            try
            {
                category.Id = Guid.NewGuid();
                _categoryDal.Add(category);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public bool Delete(Category category)
        {
            try
            {
                _categoryDal.Delete(category);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Category> GetAll()
        {
            var result = _categoryDal.GetAll();
            return result;
        }

        public bool Update(Category category)
        {
            try
            {
                _categoryDal.Update(category);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
