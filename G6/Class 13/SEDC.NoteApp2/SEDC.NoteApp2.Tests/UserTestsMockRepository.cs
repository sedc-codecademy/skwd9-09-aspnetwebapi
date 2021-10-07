using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEDC.NoteApp2.Dto.Models;
using SEDC.NoteApp2.Services.Implementations;
using SEDC.NoteApp2.Services.Interfaces;
using SEDC.NoteApp2.Shared;
using SEDC.NoteApp2.Tests.MockRepositories;

namespace SEDC.NoteApp2.Tests
{
    [TestClass]
    public class UserTestsMockRepository
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

            IUserService userService = new UserService(MockUserRepository.GetMockUserRepository(), options);
            string username = "bob007";
            string password = "123456sedc";

            // Act
            TokenDto result = userService.Authenticate(username, password);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(!string.IsNullOrEmpty(result.Token));
        }

        [TestMethod]
        public void Authenticate_InvalidUsernamePassword_Null()
        {
            // Arrange
            IOptions<AppSettings> options =
                Options.Create(
                    new AppSettings
                    {
                        Secret = "DkYzU7ypt2UhywG3"
                    });

            IUserService userService = new UserService(MockUserRepository.GetMockUserRepository(), options);
            string username = "NonExisting";
            string password = "1235456789876543";

            // Act
            TokenDto result = userService.Authenticate(username, password);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Register_ValidData_RegisterUser()
        {
            // Arrange
            IOptions<AppSettings> options =
                Options.Create(
                    new AppSettings
                    {
                        Secret = "DkYzU7ypt2UhywG3"
                    });

            IUserService userService = new UserService(MockUserRepository.GetMockUserRepository(), options);

            RegisterUserDto registerUserDto = new RegisterUserDto()
            {
                Id = 10,
                FirstName = "Greg",
                Password = "123456greg",
                Username = "gregsuper",
                Address = "Macedonia",
                Age = 30,
            };

            // Act
            userService.AddUser(registerUserDto);

            // Assert
            UserDto userDto = userService.GetUserById(registerUserDto.Id);
            Assert.AreEqual(registerUserDto.FirstName, userDto.FirstName);
            Assert.AreEqual(registerUserDto.LastName, userDto.LastName);
        }

        [TestMethod]
        public void GetUserById_ValidData_User()
        {
            // Arrange
            IOptions<AppSettings> options =
                Options.Create(
                    new AppSettings
                    {
                        Secret = "DkYzU7ypt2UhywG3"
                    });

            IUserService userService = new UserService(MockUserRepository.GetMockUserRepository(), options);
            int userId = 100;
            string username = "username.moq";

            // Act
            UserDto userDto = userService.GetUserById(userId);

            // Assert
            Assert.AreEqual(userDto.Username, username);
        }
    }
}
