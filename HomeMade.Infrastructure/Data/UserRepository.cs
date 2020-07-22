﻿using HomeMade.Core.Models;
using HomeMade.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeMade.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User Add(User user)
        {
            _dbContext.Users.Add(user);

            _dbContext.SaveChanges();

            return user;
        }

        public User Get(int id)
        {
            return _dbContext.Users.Include(u => u.Recipes).SingleOrDefault(u => u.Id == id);
        }

        public User Update(User updatedUser)
        {
            var currentUser = _dbContext.Users.Find(updatedUser.Id);

            if (currentUser == null) return null;

            _dbContext.Entry(currentUser).CurrentValues.SetValues(updatedUser);

            _dbContext.Users.Update(currentUser);

            _dbContext.SaveChanges();

            return currentUser;
        }

        public void Remove(User user)
        {
            _dbContext.Users.Remove(user);

            _dbContext.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users.Include(u => u.Recipes).ToList();
        }
    }
}
