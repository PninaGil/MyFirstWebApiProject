using DTO;
using Entities;
using Repository;


namespace Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AddUser(UserDTO userDTO)
        {
            return await _userRepository.AddUser(userDTO);
        }

        public async Task<User> GetUserByUserNameAndPassword(string email, string password)
        {
            return await _userRepository.GetUserByEmailAndPassword(email, password);
        }

        public async Task UpdateUser(int id, User userToUpdate)
        {
            await _userRepository.UpdateUser(id, userToUpdate);
        }
        public int checkpassword(string pwd)
        {
            var result =  Zxcvbn.Core.EvaluatePassword(pwd);
            return result.Score;
        }
    }
}