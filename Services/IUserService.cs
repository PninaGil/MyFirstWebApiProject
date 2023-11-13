﻿using Entities;

namespace Services
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        int checkpassword(string pwd);
        Task<User> GetUserByUserNameAndPassword(string email, string password);
        Task UpdateUser(int id, User userToUpdate);
    }
}