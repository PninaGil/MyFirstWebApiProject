using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using DTO;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyStoreContext _myStoreContext;
        IMapper _mapper;

        public UserRepository(MyStoreContext myStoreContext, IMapper mapper)
        {
            _myStoreContext = myStoreContext;
            _mapper = mapper;
            
        }


        public async Task<User> AddUser(UserDTO userDTO)
        {
            User user = _mapper.Map<UserDTO, User>(userDTO);
            await _myStoreContext.Users.AddAsync(user);
            await _myStoreContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByEmailAndPassword(string email, string password)
        {
            return await _myStoreContext.Users.Where(user => user.Email == email && user.Password == password).FirstOrDefaultAsync();
             
        }

        public async Task UpdateUser(int id, User userToUpdate)
        {
            _myStoreContext.Users.Update(userToUpdate);
            await _myStoreContext.SaveChangesAsync();
        }
    }
}
