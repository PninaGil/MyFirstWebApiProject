using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Moq.EntityFrameworkCore;
using Xunit;


namespace Test.Repository
{
    public class UserRepositoryIntegrationTest
    {
        private readonly MyStoreContext _dbContext;
        private readonly UserRepository _userRepository;

        public UserRepositoryIntegrationTest(DatabaseFixture databaseFixture)
        {
            _dbContext = databaseFixture.Context;
            _userRepository = new UserRepository(_dbContext, null);
        }
        [Fact]
        public async Task GetUser_ValidCredentials_ReturnsUser()
        {
            var email = "nomi@gmail.com";
            var password = "123456";
            var user = new User { Email = email, Password = password, FirstName = "Nomi", LastName = "Magnus" };
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            var result = await _userRepository.GetUserByEmailAndPassword(email, password);

            Xunit.Assert.NotNull(result);
        }
    }
}
