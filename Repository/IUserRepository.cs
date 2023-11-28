using DTO;
using Entities;

namespace Repository
{
    public interface IUserRepository
    {
        Task<User> AddUser(UserDTO userDTO);
        Task<User> GetUserByEmailAndPassword(string email, string password);
        Task UpdateUser(int id, User userToUpdate);
    }
}