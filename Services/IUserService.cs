using DTO;
using Entities;

namespace Services
{
    public interface IUserService
    {
        Task<User> AddUser(UserDTO userDTO);
        int checkpassword(string pwd);
        Task<User> GetUserByUserNameAndPassword(string email, string password);
        Task UpdateUser(int id, User userToUpdate);
    }
}