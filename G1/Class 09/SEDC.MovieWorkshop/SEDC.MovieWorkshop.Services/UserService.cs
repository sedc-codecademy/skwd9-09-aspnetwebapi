using SEDC.MovieWorkshop.DataAccess;
using SEDC.MovieWorkshop.DataModels;
using SEDC.MovieWorkshop.Models;
using SEDC.MovieWorkshop.Services.Helpers.Mappers;
using SEDC.MovieWorkshop.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.MovieWorkshop.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Movie> _movieRepository;
        public UserService(IRepository<User> userRepository, IRepository<Movie> movieRepository)
        {
            _userRepository = userRepository;
            _movieRepository = movieRepository;
        }
        public ResultModel CreateUser(UserModel user)
        {
            throw new NotImplementedException();
        }

        public List<UserModel> GetAllUsers()
        {
            return _userRepository.GetAll().Select(user => UserMapper.UserToUserModel(user)).ToList();
        }

        public UserModel GetUserById(int userId)
        {
            var user = _userRepository.GetById(userId);
            return UserMapper.UserToUserModel(user);
        }

        public UserResultModel GetUserMoviesRented(int userId)
        {
            var user = _userRepository.GetById(userId);
            if (user is null)
            {
                return new UserResultModel { ErrorMessage = "User does not exist", Succeeded = false };
            }

            var userMovies = _movieRepository.GetAll().Where(x => x.Id == user.Id).ToList();

            return new UserResultModel
            {
                Succeeded = true,
                UserMovies = MovieMapper.MoviesToMoviesDTOList(userMovies)
            };
        }
    }
}
