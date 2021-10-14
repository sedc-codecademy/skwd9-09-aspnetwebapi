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
    public class UserTestsMoq
    {
        [TestMethod]
        public void Login_ValidUsernamePassword_ValidToken_Moq()
        {
            // Arrange
            IOptions<AppSettings> mockOptions = Options.Create<AppSettings>(new AppSettings()
            {
                SecretKey = "SECRET FOR TESTING"
            });

            IUserService userService = new UserService(MockHelper.MockUserRepository(), mockOptions);
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
        public void Login_InvalidUsernamePassword_Exception_Moq()
        {
            // Arrange
            IOptions<AppSettings> mockOptions = Options.Create<AppSettings>(new AppSettings()
            {
                SecretKey = "SECRET FOR TESTING"
            });

            IUserService userService = new UserService(MockHelper.MockUserRepository(), mockOptions);
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
