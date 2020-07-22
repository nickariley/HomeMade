using HomeMade.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeMade.Core.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public User Add(User user)
        {
            _userRepo.Add(user);
            return user;
        }

        public User Get(int id)
        {
            return _userRepo.Get(id);
        }

        public User Update(User updatedUser)
        {
            var user = _userRepo.Update(updatedUser);
            return user;
        }

        public void Remove(User user)
        {
            _userRepo.Remove(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepo.GetAll();
        }
    }
}
