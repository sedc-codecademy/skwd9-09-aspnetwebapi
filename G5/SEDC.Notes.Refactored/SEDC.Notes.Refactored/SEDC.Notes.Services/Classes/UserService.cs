using SEDC.Notes.DataAccess.Repositories.Interfaces;
using SEDC.Notes.DomainModels;
using SEDC.Notes.RequestModels;
using SEDC.Notes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SEDC.Notes.Services.Classes
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepositoty;

        public UserService(IRepository<User> userRepositoty)
        {
            _userRepositoty = userRepositoty;
        }


        public void Register(RegisterRequestModel requestModel)
        {
            if (requestModel.Password != requestModel.ConfirmPassword) 
            {
                //throw new Exception("Password did not match!");
            }

            var md5 = new MD5CryptoServiceProvider();
            var md5Data = md5.ComputeHash(Encoding.ASCII.GetBytes(requestModel.Password));
            var hashedPassword = Encoding.ASCII.GetString(md5Data);

            var user = new User()
            {
                Username = requestModel.Username,
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName,
                Password = hashedPassword
            };

            _userRepositoty.Add(user);
        }
    }
}
