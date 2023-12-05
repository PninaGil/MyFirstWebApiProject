using DTO;
using Entities;

namespace Repository
{
    public interface IUserRepository
    {
        Task<User> AddUser(UserLoginDTO userLoginDTO);
        Task<User> GetUserByEmailAndPassword(string email, string password);
        Task<User> GetUserById(int id);
        Task<User> UpdateUser(int id, User userToUpdate);
    }
}