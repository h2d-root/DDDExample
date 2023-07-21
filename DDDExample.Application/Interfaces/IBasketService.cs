using DDDExample.Application.DTO;
using DDDExample.domain.Entity;

namespace DDDExample.Application.Interfaces
{
    public interface IBasketService
    {
        public bool AddProduct(BasketDto dto);
        public bool RemoveProduct(BasketDto dto);
        public bool BuyProduct(Basket basket, Guid userId);
        public List<Basket> GetAll(Guid userId);
    }
}
