using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SEDC.NoteApp2.DataAccess.Interfaces;
using SEDC.NoteApp2.Domain.Models;
using SEDC.NoteApp2.Dto.Models;
using SEDC.NoteApp2.Mappers;
using SEDC.NoteApp2.Services.Interfaces;
using SEDC.NoteApp2.Shared;
using SEDC.NoteApp2.Shared.Helpers;
using Serilog;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SEDC.NoteApp2.Services.Implementations
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

        public void AddUser(RegisterUserDto userDto)
        {
            Log.Debug($"Trying to add user with username: {userDto.Username}");
            User user = userDto.ToUser();
            _userRepository.Add(user);
        }

        public TokenDto Authenticate(string username, string password)
        {
            Log.Debug($"Trying to authenticate user with credentials: {username}:{password}");
            User user = _userRepository.GetUserByUsernameAndPassword(username, password.GenerateMD5());

            if (user == null)
            {
                Log.Warning($"Failed user authentication with {username}:{password}");
                return null;
            }

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_options.Value.Secret);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim("CustomClaimTypeUserAddress", user.Address)
                    }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            TokenDto tokenDto = new TokenDto()
            {
                Token = tokenHandler.WriteToken(token)
            };

            Log.Information($"Token generated for username: {username}");

            return tokenDto;
        }

        public void DeleteUser(int id)
        {
            Log.Debug($"Trying to delete user with id: {id}");
            User user = _userRepository.GetById(id);
            _userRepository.Delete(user);
        }

        public List<UserDto> GetAllUsers()
        {
            Log.Debug($"Trying to execute get all users");
            List<User> users = _userRepository.GetAll();
            List<UserDto> userDtos = new List<UserDto>();

            foreach (User item in users)
            {
                userDtos.Add(item.ToUserDto());
            }

            return userDtos;
        }

        public List<UserDto> GetAllUsersIncludeNotes()
        {
            Log.Debug($"Trying to execute GetAllUsersIncludeNotes");
            List<User> users = _userRepository.GetAllIncludeNotes();
            List<UserDto> userDtos = new List<UserDto>();

            foreach (User item in users)
            {
                userDtos.Add(item.ToUserDto());
            }

            return userDtos;
        }

        public UserDto GetUserById(int id)
        {
            Log.Debug($"Trying to execute GetUserById Id: {id}");
            User user = _userRepository.GetById(id);
            UserDto userDto = UserMapper.ToUserDto(user);
            return userDto;
        }

        public UserDto GetUserByIdIncludeNotes(int id)
        {
            Log.Debug($"Trying to execute GetUserByIdIncludeNotes Id: {id}");
            User user = _userRepository.GetByIdIncludeNotes(id);
            UserDto userDto = UserMapper.ToUserDto(user);
            return userDto;
        }

        public void UpdateUser(UserDto userDto)
        {
            Log.Debug($"Trying to update user with username: {userDto.Username}");
            User user = userDto.ToUser();
            _userRepository.Update(user);
        }
    }
}
