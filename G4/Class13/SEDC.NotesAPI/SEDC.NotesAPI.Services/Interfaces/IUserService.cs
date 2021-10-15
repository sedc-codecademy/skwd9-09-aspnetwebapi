using SEDC.NotesAPI.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesAPI.Services.Interfaces
{
    public interface IUserService
    {
        void Register(RegisterUserModel registerUserModel);
        string Login(LoginUserModel loginUserModel);
 
    }
}
