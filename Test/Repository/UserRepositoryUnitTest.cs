using Entities;
using Moq;
using Moq.EntityFrameworkCore;
using Repository;
using Xunit;
namespace Test.Repository
{
    [TestClass]
    public class UserRepositoryUnitTest
    {
      

        [Fact]
        public async void AddUserById_ValidCredentials_ReturnUser()
        {
            var user = new User { Email= "John Doe", Password="111" };
            var mockContext = new Mock<MyStoreContext>();
            var users = new List<User>() { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            var userRepository = new UserRepository(mockContext.Object,null);

            var result = await userRepository.GetUserByEmailAndPassword("John Doe", "111");

            Xunit.Assert.Equal(user, result);
    }
    }
}