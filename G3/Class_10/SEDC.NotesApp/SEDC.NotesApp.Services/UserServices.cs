using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SEDC.NotesApp.DtoModels;
using SEDC.NotesApp.Helpers.Mappers;
using SEDC.NotesApp.Models.DbModels;
using SEDC.NotesApp.Repositories;
using SEDC.NotesApp.Services.Helpers;
using SEDC.NotesApp.Services.Interfaces;
using SEDC.NotesApp.Shared.Exceptions;
using SEDC.NotesApp.Shared.Mappers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SEDC.NotesApp.Services
{
    public class UserServices : IUserService
    {
        private readonly IRepository<User> _userRepo;
        private readonly IOptions<AppSettings> _options;
        public UserServices(IRepository<User> userRepo, IOptions<AppSettings> options)
        {
            _userRepo = userRepo;
            _options = options;
        }

        public UserDto Authenticate(LogInModel model)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(model.Password));
            var password = Encoding.ASCII.GetString(md5data);
            var user = _userRepo.GetAll().SingleOrDefault(user =>
                user.UserName == model.UserName && user.Password == password
            );
            if (user == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.Value.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    }
                ),
                Expires = DateTime.UtcNow.AddMinutes(2),
                SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
                    )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var userModel = new UserDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Token = tokenHandler.WriteToken(token),
                Notes = user.Notes.Select(x => NoteMapper.MapNoteToNoteDtoModel(x)).ToList()
            };
            return userModel;
        }

        public void Create(RegisterModel user)
        {
            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
            {
                throw new BadRequestException("UserName and password are required");
            }
            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName))
            {
                throw new BadRequestException("FirstName and LastName are required");
            }
            if (!ValidateUserName(user.UserName))
            {
                throw new BadRequestException($" {user.UserName} UserName is already in use");
            }
            if (user.Password != user.ConfirmPassword)
            {
                throw new BadRequestException("Passwords did not match!");
            }

            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(user.Password));
            var hashedPassword = Encoding.ASCII.GetString(md5data);

            User newUser = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Password = hashedPassword
            };
            _userRepo.Add(newUser);
        }

        public void Delete(int id)
        {
            User user = _userRepo.GetById(id);
            if (user == null)
            {
                throw new UserException(id, "no user found");
            }
            _userRepo.Remove(id);
        }

        public List<UserDto> GetAll()
        {
            return _userRepo.GetAll().Select(user => user.ToUserDto()).ToList();
        }

        public UserDto GetById(int id)
        {
            User user = _userRepo.GetById(id);
            if (user == null)
            {
                return null;
            }
            return user.ToUserDto();
        }

        public void Update(UserDto user)
        {
            User userDb = _userRepo.GetById(user.Id);
            if (userDb == null)
            {
                throw new UserException(user.Id, "no user found");
            }
            _userRepo.Update(user.ToUser());
        }


        private bool ValidateUserName(string username)
        {
            return _userRepo.GetAll().All(user => user.UserName != username);
        }



    }
}
