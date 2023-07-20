using DDDExample.domain.Entity;

namespace DDDExample.Application.Interfaces
{
    public interface IAddressService
    {
        public List<Address> GetAddresses();
        public bool AddAdress(Address address);
        public List<Address> GetUserAdress(Guid userId);
    }
}
