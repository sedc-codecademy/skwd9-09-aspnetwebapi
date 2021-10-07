using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEDC.NotesApp.Models;
using SEDC.NotesApp.Services;
using SEDC.NotesApp.Services.Helpers;
using SEDC.NotesApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesApp.Tests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void Autenthicate_ValidUsernamePassword_ValidToken()
        {
            // Arrange 
            string username = "bob007";
            string password = "12345sedc";
            IOptions<AppSettings> mockOptions = Options.Create<AppSettings>(new AppSettings
            {
                Secret = "SECRET FOR TESTING"
            });
            IUserService userService = new UserService(new FakeUserRepository(), mockOptions);


            // Act
            UserModel result = userService.Authenticate(username, password);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Token != null && result.Token != string.Empty);
        }

        [TestMethod]
        public void Autenthicate_InvalidUsernamePassword_Null()
        {
            // Arrange 
            string username = "NonExisting";
            string password = "1234567";
            IOptions<AppSettings> mockOptions = Options.Create<AppSettings>(new AppSettings
            {
                Secret = "SECRET FOR TESTING"
            });
            IUserService userService = new UserService(new FakeUserRepository(), mockOptions);


            // Act
            UserModel result = userService.Authenticate(username, password);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Register_ValidData_RegisteredUser()
        {
            // Arrange 
            IOptions<AppSettings> mockOptions = Options.Create<AppSettings>(new AppSettings
            {
                Secret = "SECRET FOR TESTING"
            });
            IUserService userService = new UserService(new FakeUserRepository(), mockOptions);
            RegisterModel user = new RegisterModel
            {
                FirstName = "Greg",
                LastName = "Gregsky",
                Password = "1234greg",
                ConfirmPassword = "1234greg",
                Username = "gregsuperstar"
            };


            // Act
           
            userService.Register(user);

            // Assert
            UserModel newUser = userService.Authenticate(user.Username, user.Password);
            Assert.AreEqual(user.FirstName, newUser.FirstName);
            Assert.AreEqual(user.LastName, newUser.LastName);
        }
    }
}
