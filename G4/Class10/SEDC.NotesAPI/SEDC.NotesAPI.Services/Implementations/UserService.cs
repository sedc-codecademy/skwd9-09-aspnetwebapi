using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SEDC.NotesAPI.DataAccess.Interfaces;
using SEDC.NotesAPI.Domain.Models;
using SEDC.NotesAPI.Models.Users;
using SEDC.NotesAPI.Services.Interfaces;
using SEDC.NotesAPI.Shared.CustomEntities;
using SEDC.NotesAPI.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace SEDC.NotesAPI.Services.Implementations
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IOptions<AppSettings> _options;

        public UserService(IUserRepository userRepository, IOptions<AppSettings> options)
        {
            _userRepository = userRepository;
            _options = options;
        }
        public string Login(LoginUserModel loginUserModel)
        {
            // We create an instance of the MD5CryptoServiceProvider that will help us create the hash
            var md5 = new MD5CryptoServiceProvider();
            // We create the hash from the password
            var md5Data = md5.ComputeHash(Encoding.ASCII.GetBytes(loginUserModel.Password));
            // We get the hash string
            var hashedPassword = Encoding.ASCII.GetString(md5Data);

            // in DB we compare two hashed passwords
            User userDb = _userRepository.LoginUser(loginUserModel.Username, hashedPassword);
            if(userDb == null)
            {
                throw new NotFoundException($"User with username {loginUserModel.Username} cannot be found");
            }

            // Generate JWT token
            //Install System.IdentityModel.Tokens.Jwt - NuGet

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            //get the SecretKey from AppSettings
            byte[] secretKeyBytes = Encoding.ASCII.GetBytes(_options.Value.SecretKey);
            //configure the token
            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(7),
                //signature definition
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes),
                    SecurityAlgorithms.HmacSha256Signature),
                //payload
                Subject = new ClaimsIdentity(
                    new[]
                    {
                            new Claim(ClaimTypes.Name, userDb.Username),
                            new Claim(ClaimTypes.NameIdentifier, userDb.Id.ToString()),
                            new Claim("userFullName", $"{userDb.FirstName} {userDb.LastName}"),
                    }
                )
            };
            SecurityToken token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            // convert it to string
            string tokenString = jwtSecurityTokenHandler.WriteToken(token);
            return tokenString;

        }

        public void Register(RegisterUserModel registerUserModel)
        {
            ValidateUser(registerUserModel);

            // take password and hash it
            // We create an instance of the MD5CryptoServiceProvider that will help us create the hash
            var md5 = new MD5CryptoServiceProvider();
            // We create the hash from the password
            var md5Data = md5.ComputeHash(Encoding.ASCII.GetBytes(registerUserModel.Password));
            // We get the hash string
            var hashedPassword = Encoding.ASCII.GetString(md5Data);

            // netikazuvam123 -> dsfhai83473seidfsa893-495-233473awkkwsfdne

            // move this to a mapper method
            User newUser = new User
            {
                FirstName = registerUserModel.FirstName,
                LastName = registerUserModel.LastName,
                Username = registerUserModel.Username,
                Password = hashedPassword // we send the hashed password to the DB
            };
            _userRepository.Add(newUser);
        }

        private void ValidateUser(RegisterUserModel registerUserModel)
        {
            if (string.IsNullOrEmpty(registerUserModel.Username) || string.IsNullOrEmpty(registerUserModel.Password))
            {
                throw new UserException("Username and password are required fields");
            }
            if (registerUserModel.Username.Length > 30)
            {
                throw new UserException("Username can contain max 30 characters");
            }
            if (registerUserModel.FirstName.Length > 50 || registerUserModel.LastName.Length > 50)
            {
                throw new UserException("Firstname and Lastname can contain maximum 50 characters!");
            }
            if (!IsUserNameUnique(registerUserModel.Username))
            {
                throw new UserException("A user with this username already exists!");
            }
            if (registerUserModel.Password != registerUserModel.ConfirmedPassword)
            {
                throw new UserException("The passwords do not match!");
            }
            if (!IsPasswordValid(registerUserModel.Password))
            {
                throw new UserException("The password is not complex enough!");
            }
        }

        private bool IsPasswordValid(string password)
        {
            Regex passwordRegex = new Regex("^(?=.*[0-9])(?=.*[a-z]).{6,20}$");
            return passwordRegex.Match(password).Success;
        }

        private bool IsUserNameUnique(string username)
        {
            return _userRepository.GetUserByUsername(username) == null;
        }
    }
}
