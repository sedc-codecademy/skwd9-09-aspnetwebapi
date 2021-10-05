using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEDC.NoteApp2.Dto.Models;
using SEDC.NoteApp2.Services.Implementations;
using SEDC.NoteApp2.Services.Interfaces;
using SEDC.NoteApp2.Shared;
using SEDC.NoteApp2.Tests.FakeRepositories;

namespace SEDC.NoteApp2.Tests
{
    [TestClass]
    public class UserTestsFakeRepository
    {
        [TestMethod]
        public void Authenticate_ValidUsernamePassword_ValidToken()
        {
            // Arrange
            IOptions<AppSettings> options =
                Options.Create(
                    new AppSettings
                    {
                        Secret = "DkYzU7ypt2UhywG3"
                    });

            IUserService userService = new UserService(new FakeUserRepository(), options);
            string username = "bob007";
            string password = "123456sedc";

            // Act
            TokenDto result = userService.Authenticate(username, password);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(!string.IsNullOrEmpty(result.Token));
        }
    }
}
