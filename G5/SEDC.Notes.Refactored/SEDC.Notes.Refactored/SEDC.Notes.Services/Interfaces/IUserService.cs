using SEDC.Notes.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Notes.Services.Interfaces
{
    public interface IUserService
    {
        void Register(RegisterRequestModel requestModel);
    }
}
