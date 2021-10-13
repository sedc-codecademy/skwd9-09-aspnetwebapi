using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEDC.NotesAPI.Models.Users;
using SEDC.NotesAPI.Services.Implementations;
using SEDC.NotesAPI.Services.Interfaces;
using SEDC.NotesAPI.Shared.CustomEntities;
using SEDC.NotesAPI.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void Login_ValidUsernamePassword_ValidToken()
        {
            // Arrange
            IOptions<AppSettings> mockOptions = Options.Create<AppSettings>(new AppSettings()
            {
                SecretKey = "SECRET FOR TESTING"
            });

            IUserService userService = new UserService(new FakeUserRepository(), mockOptions);
            string username = "bob123";
            string password = "netikazuvam123";

            // Act
            string result = userService.Login(new LoginUserModel()
            {
                Username = username,
                Password = password
            });

            // Assert
            Assert.IsTrue(!string.IsNullOrEmpty(result));
        }

        [ExpectedException(typeof(NotFoundException))]
        [TestMethod]
        public void Login_InvalidUsernamePassword_Exception()
        {
            // Arrange
            IOptions<AppSettings> mockOptions = Options.Create<AppSettings>(new AppSettings()
            {
                SecretKey = "SECRET FOR TESTING"
            });

            IUserService userService = new UserService(new FakeUserRepository(), mockOptions);
            string username = "idontexist";
            string password = "hello123";

            // Act
            string result = userService.Login(new LoginUserModel()
            {
                Username = username,
                Password = password
            });

            // Assert
        }
    }
}
