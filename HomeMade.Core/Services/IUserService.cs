using HomeMade.Core.Models;
using System.Collections.Generic;

namespace HomeMade.Core.Services
{
    public interface IUserService
    {
        User Add(User user);
        User Get(int id);
        IEnumerable<User> GetAll();
        void Remove(User user);
        User Update(User updatedUser);
    }
}