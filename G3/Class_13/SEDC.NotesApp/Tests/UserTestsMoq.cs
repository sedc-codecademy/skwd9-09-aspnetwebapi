using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEDC.NotesApp.DtoModels;
using SEDC.NotesApp.Services;
using SEDC.NotesApp.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestClass]
    public class UserTestsMoq
    {
        [TestMethod]
        public void Authenticate_ValidCredentials_ValidToken()
        {
            // Arrange
            IOptions<AppSettings> mockOptions = Options.Create<AppSettings>(new AppSettings()
            {
                Secret = "SECRET FOR TESTING"
            });
            UserServices service = new UserServices(MockHelper.MockUserRepository(), mockOptions);
            LogInModel loginModel = new LogInModel()
            {
                UserName = "John_Doe",
                Password = "sedc123"
            };

            //Act
            UserDto loggedUser = service.Authenticate(loginModel);

            // Assert
            Assert.IsNotNull(loggedUser);
            Assert.IsFalse(string.IsNullOrEmpty(loggedUser.Token));
        }

        [TestMethod]
        public void Authenticate_InvalidCredentials_Null()
        {
            // Arrange
            IOptions<AppSettings> mockOptions = Options.Create<AppSettings>(new AppSettings()
            {
                Secret = "SECRET FOR TESTING"
            });
            UserServices service = new UserServices(MockHelper.MockUserRepository(), mockOptions);
            LogInModel loginModel = new LogInModel()
            {
                UserName = "Nepostoecki_user",
                Password = "sedc123"
            };

            //act
            var result = service.Authenticate(loginModel);
            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Create_ValidData_RegisteredUser()
        {
            // Arrange
            IOptions<AppSettings> mockOptions = Options.Create<AppSettings>(new AppSettings()
            {
                Secret = "SECRET FOR TESTING"
            });
            UserServices service = new UserServices(MockHelper.MockUserRepository(), mockOptions);
            RegisterModel model = new RegisterModel()
            {
                FirstName = "Bob",
                LastName = "Bobsky",
                UserName = "Bobsy",
                Password = "bob123",
                ConfirmPassword = "bob123"
            };

            // Act
            service.Create(model);

            // Assert
            var newUser = service.Authenticate(new LogInModel()
            {
                UserName = "Bobsy",
                Password = "bob123"
            });
            Assert.IsNotNull(newUser);
            Assert.AreEqual(model.FirstName, newUser.FirstName);
            Assert.AreEqual(model.LastName, newUser.LastName);
        }

    }
}
