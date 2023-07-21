using DDDExample.Application.DTO;
using DDDExample.Application.Interfaces;
using DDDExample.domain.Entity;
using DDDExample.Infrastructure.Entities;

namespace DDDExample.Application.Classes
{
    public class BasketManager : IBasketService
    {
        IBasketDal _basketDal;
        IOrderDal _orderDal;
        IProductDal _productDal;

        public BasketManager(IBasketDal basketDal, IOrderDal orderDal, IProductDal productDal)
        {
            _basketDal = basketDal;
            _orderDal = orderDal;
            _productDal = productDal;
        }

        public bool AddProduct(BasketDto dto)
        {
            try
            {
                Basket basket = new Basket();
                //basket.Adet = dto.Adet;
                if (dto.Adet == 0)
                {
                    dto.Adet = 1;
                }
                var control = _basketDal.Get(b=>b.ProductId == dto.ProductId && b.UserId == dto.UserId);
                if (control != null)
                {
                    control.Adet += dto.Adet;
                    basket.Adet = control.Adet;
                    _basketDal.Update(control);
                }
                else
                {

                var product = _productDal.Get(p => p.Id == dto.ProductId);
                basket.UserId=dto.UserId;
                basket.ProductId = dto.ProductId;
                basket.NewPrice = product.Price;
                basket.ProductName = product.ProductName;
                _basketDal.Add(basket);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Basket> GetAll(Guid userId)
        {
            var result = _basketDal.GetAll(b=>b.UserId == userId);
            return result;
        }
        public bool BuyProduct(Basket basket, Guid userId)
        {
            try
            {
                var baskets = _basketDal.GetAll(x=>x.UserId == userId);
                List<Order> orders = new List<Order>();
                foreach (var item in baskets)
                {
                    Order order = new Order();
                    order.Price = basket.NewPrice;
                    order.UserId = basket.UserId;
                    order.ProductName = basket.ProductName;
                    order.ProductId = basket.ProductId;
                    order.State = "hazırlanıyor";
                    _orderDal.Add(order);
                    _basketDal.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveProduct(BasketDto dto)
        {

            var userBaskets = _basketDal.Get(b=> b.UserId == dto.UserId && b.ProductId == dto.ProductId);
            try
            {
                _basketDal.Delete(userBaskets);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
