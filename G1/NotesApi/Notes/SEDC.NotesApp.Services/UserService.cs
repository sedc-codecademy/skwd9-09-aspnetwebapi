using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SEDC.NotesApp.DataAccess;
using SEDC.NotesApp.DataModels;
using SEDC.NotesApp.Models;
using SEDC.NotesApp.Services.Helpers;
using SEDC.NotesApp.Services.Helpers.Mappers;
using SEDC.NotesApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SEDC.NotesApp.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IOptions<AppSettings> _options;

        public UserService(IRepository<User> userRepository, IOptions<AppSettings> options)
        {
            _userRepository = userRepository;
            _options = options;
        }

        public UserModel Authenticate(string username, string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            var passwordData = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            var hashedPassword = Encoding.ASCII.GetString(passwordData);


            var user = _userRepository.GetAll().SingleOrDefault(x => x.Username == username && x.Password == hashedPassword);

            if (user == null) return null;


            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Name, $"{ user.Firstname } { user.LastName}"),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var userModel = new UserModel
            {
                Id = user.Id,
                FirstName = user.Firstname,
                LastName = user.LastName,
                Username = user.Username,
                Token = tokenHandler.WriteToken(token)
            };

            return userModel;
        }

        public void Register(RegisterModel model)
        {
            //TODO: Add appropriate validations



            var md5 = new MD5CryptoServiceProvider();
            byte[] passwordData = md5.ComputeHash(Encoding.ASCII.GetBytes(model.Password));
            string hashedPassword = Encoding.ASCII.GetString(passwordData);

            var user = UserMapper.RegisterModelToUser(model);
            user.Password = hashedPassword;

            _userRepository.Add(user);
        }
    }
}
