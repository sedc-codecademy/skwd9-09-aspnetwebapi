using SEDC.MovieWorkshop.DataModels;
using SEDC.MovieWorkshop.Models;
using System.Linq;

namespace SEDC.MovieWorkshop.Services.Helpers.Mappers
{
    public static class UserMapper
    {

        public static UserModel UserToUserModel(User user)
        {
            return new UserModel
            {
                Id = user.Id,
                FullName = user.FullName,
                Password = user.Password,
                Subscription = (Models.Subscription)user.Subscription,
                UserName = user.UserName
            };
        }
        public static User UserModelToUser(UserModel user)
        {
            return new User
            {
                Id = user.Id,
                FullName = user.FullName,
                Password = user.Password,
                Subscription = (DataModels.Subscription)user.Subscription,
                UserName = user.UserName
            };
        }
    }
}
