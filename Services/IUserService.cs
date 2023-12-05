using DTO;
using Entities;

namespace Services
{
    public interface IUserService
    {
        Task<User> AddUser(UserLoginDTO userLoginDTO);
        int checkpassword(string pwd);
        Task<User> GetUserByUserNameAndPassword(string email, string password);
        Task<User> GetUserById(int id);
        Task<User> UpdateUser(int id, User userToUpdate);
    }
}