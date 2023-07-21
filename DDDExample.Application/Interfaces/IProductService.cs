using DDDExample.Application.DTO;
using DDDExample.domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDExample.Application.Interfaces
{

    public interface IProductService
    {
        public bool AddProduct(Product product);
        public List<Product> GetProducts();
        public List<Product> GetByFilterProduct(ProductFilterDTO dTO);
        public List<Product> GetByCategoryProduct(Guid categoryId);
        public List<Product> GetByProductName(string productName);
    }
}
