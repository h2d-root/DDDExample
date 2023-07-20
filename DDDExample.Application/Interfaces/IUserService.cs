using DDDExample.Application.DTO;
using DDDExample.domain.Entity;

namespace DDDExample.Application.Interfaces
{
    public interface IUserService
    {
        public Guid GetByUserId(string username);
        public bool Register(User user);
        public User Login(LoginDTO login);
        public List<User> GetUsers();
        public User UserInfo(Guid id);
        public bool EditUser(EditUser editUser, Guid id);
    }
}
