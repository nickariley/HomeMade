using HomeMade.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeMade.Core.Services
{
    public interface IUserRepository
    {
        // Create
        User Add(User user);
        // Read
        User Get(int id);
        // Update
        User Update(User user);
        // Delete
        void Remove(User user);
        // List
        IEnumerable<User> GetAll(); // List? Collection? Benefits and Drawbacks?
    }
}
