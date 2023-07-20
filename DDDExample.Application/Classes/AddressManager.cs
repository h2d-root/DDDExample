using DDDExample.Application.Interfaces;
using DDDExample.domain.Entity;
using DDDExample.Infrastructure.Entities;
using System.Net;

namespace DDDExample.Application.Classes
{
    public class AddressManager : IAddressService
    {
        IAddressDal _addressDal;

        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }
        public List<Address> GetAddresses()
        {
            var result = _addressDal.GetAll();
            return result;
        }
        public bool AddAdress(Address address)
        {
            var result = _addressDal.GetAll(u => u.UserId == address.UserId);
            if (result.Count < 3)
            {
                _addressDal.Add(address);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Address> GetUserAdress(Guid userId)
        {
            var result = _addressDal.GetAll(u => u.UserId == userId);
            return result.ToList();
        }
    }
}
