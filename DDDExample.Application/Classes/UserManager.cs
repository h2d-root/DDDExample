﻿using DDDExample.Application.DTO;
using DDDExample.Application.Interfaces;
using DDDExample.domain.Entity;
using DDDExample.Infrastructure;
using DDDExample.Infrastructure.Entities;

namespace DDDExample.Application.Classes
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User Login(LoginDTO login)
        {
            var result = _userDal.Get(u=> u.UserName == login.UserName);
            if (result != null && result.Password == login.Password)
            {
                return result;
            }
            return result;
        }

        public bool Register(User user)
        {
            var result = _userDal.Get(u=>u.Email == user.Email);
            if (result == null)
            {
                _userDal.Add(user);
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public bool EditUser(EditUser editUser, Guid id)
        {
            User user = new User();
            user = _userDal.Get(u=>u.Id == id);
            if (user != null)
            {
                user.Name= editUser.Name;
                user.LastName = editUser.LastName;
                user.PhoneNumber = editUser.PhoneNumber;
                _userDal.Update(user);
                return true;
            }
            return false;
        }
        public Guid GetByUserId(string username)
        {
            var result = _userDal.Get(u=>u.UserName == username);
            return result.Id;
        }
        public List<User> GetUsers()
        {
            return _userDal.GetAll();
        }
        public User UserInfo(Guid id)
        {
            var result = _userDal.Get(u =>u.Id == id);
            return result;
        }
    }

}
