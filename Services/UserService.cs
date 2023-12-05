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

        public async Task<User> AddUser(UserLoginDTO userLoginDTO)
        {
            return await _userRepository.AddUser(userLoginDTO);
        }

        public async Task<User> GetUserByUserNameAndPassword(string email, string password)
        {
            return await _userRepository.GetUserByEmailAndPassword(email, password);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<User> UpdateUser(int id, User userToUpdate)
        {
            return await _userRepository.UpdateUser(id, userToUpdate);
        }
        public int checkpassword(string pwd)
        {
            var result =  Zxcvbn.Core.EvaluatePassword(pwd);
            return result.Score;
        }
    }
}