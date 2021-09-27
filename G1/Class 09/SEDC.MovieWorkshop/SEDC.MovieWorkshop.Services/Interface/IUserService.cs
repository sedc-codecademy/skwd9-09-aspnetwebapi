using SEDC.MovieWorkshop.Models;
using System.Collections.Generic;

namespace SEDC.MovieWorkshop.Services.Interface
{
    public interface IUserService
    {
        ResultModel CreateUser(UserModel user);
        List<UserModel> GetAllUsers();
        UserModel GetUserById(int userId);
        UserResultModel GetUserMoviesRented(int userId);
    }
}
