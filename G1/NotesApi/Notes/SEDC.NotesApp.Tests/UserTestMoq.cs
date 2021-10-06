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
    public class UserTestMoq
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
            IUserService userService = new UserService(MockHelper.MockUserRepository(), mockOptions);


            // Act
            UserModel result = userService.Authenticate(username, password);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Token != null && result.Token != string.Empty);
        }

        // TODO Autenthicate_InvalidUsernamePassword_Null
    }
}
