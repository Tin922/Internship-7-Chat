﻿using Chat.Data.Entities;
using Chat.Data.Entities.Models;
using Chat.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Chat.Domain.Repositories
{
    public class UserRepository : BaseRepository
    {
        public UserRepository(ChatDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType Add(User user)
        {
            DbContext.Users.Add(user);

            return SaveChanges();
        }

        public ResponseResultType Delete(int id)
        {
            var userToDelete = DbContext.Users.Find(id);
            if (userToDelete is null)
            {
                return ResponseResultType.NotFound;
            }

            DbContext.Users.Remove(userToDelete);

            return SaveChanges();
        }

        public ResponseResultType Update(User user, int id)
        {
            var userToUpdate = DbContext.Users.Find(id);
            if (userToUpdate is null)
            {
                return ResponseResultType.NotFound;
            }

            userToUpdate.Email = user.Email;
            userToUpdate.Password = user.Password;

            return SaveChanges();
        }

        public User? GetById(int id) => DbContext.Users.FirstOrDefault(u => u.UserId == id);
        public User? GetByEmail(string email) => DbContext.Users.FirstOrDefault(u => u.Email == email);

        public ICollection<User> GetAll() => DbContext.Users.ToList();

        public ResponseResultType UpdateRole(int userId, bool isAdmin)
        {
            var userToUpdate = DbContext.Users.Find(userId);
            if (userToUpdate is null)
            {
                return ResponseResultType.NotFound;
            }

            userToUpdate.IsAdmin = isAdmin;

            return SaveChanges();
        }
        public ResponseResultType UpdateEmail(int userId, string newEmail)
        {
            var userToUpdate = DbContext.Users.Find(userId);
            if (userToUpdate is null)
            {
                return ResponseResultType.NotFound;
            }

            userToUpdate.Email = newEmail;

            return SaveChanges();
        }
    }
}
