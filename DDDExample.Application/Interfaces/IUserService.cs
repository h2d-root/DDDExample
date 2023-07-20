using DDDExample.Application.DTO;
using DDDExample.domain.Entity;

namespace DDDExample.Application.Interfaces
{
    public interface IUserService
    {
        public bool Register(User user);
        public User Login(LoginDTO login);
    }
}
