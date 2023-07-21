using DDDExample.Application.DTO;
using DDDExample.Application.Interfaces;
using DDDExample.domain.Entity;
using DDDExample.Infrastructure.Entities;

namespace DDDExample.Application.Classes
{

    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryDal _categoryDal;
        public ProductManager(IProductDal productDal, ICategoryDal categoryDal)
        {
            _productDal = productDal;
            _categoryDal = categoryDal;
        }
        public bool AddProduct(Product product)
        {
            try
            {
                _productDal.Add(product);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Product> GetByCategoryProduct(Guid categoryId)
        {
            var category = _categoryDal.Get(c=>c.Id == categoryId);
            var result = _productDal.GetAll(p=>p.CategoryId ==category.Id);
            return result;
        }

        public List<Product> GetByFilterProduct(ProductFilterDTO dTO)
        {
            var result = _productDal.GetAll(p=> dTO.MinPrice < p.Price && dTO.MaxPrice > p.Price);
            return result;
        }

        public List<Product> GetByProductName(string productName)
        {
            var result = _productDal.GetAll(c=>c.ProductName.Contains(productName));
            return result;
        }

        public List<Product> GetProducts()
        {
            var result = _productDal.GetAll();
            return result;
        }
    }
}
