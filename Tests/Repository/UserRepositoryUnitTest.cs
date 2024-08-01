using Entities;
using Moq;
using Moq.EntityFrameworkCore;
using Repository;
namespace Tests.Repository;

[TestClass]
public class UserRepositoryUnitTest
{
  

    [Fact]
    public async void AddUserById_ValidCredentials_ReturnUser()
    {
        var user = new User { Email= "john@doe.com", Password="111" };
        var mockContext = new Mock<MyStoreContext>();
        var users = new List<User>() { user };
        mockContext.Setup(x => x.Users).ReturnsDbSet(users);

        var userRepository = new UserRepository(mockContext.Object,null);

        var result = await userRepository.GetUserByEmailAndPassword("john@doe.com", "111");

        Xunit.Assert.Equal(user, result);
}
}