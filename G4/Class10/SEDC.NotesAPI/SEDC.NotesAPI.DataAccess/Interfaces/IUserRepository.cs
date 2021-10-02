using SEDC.NotesAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static SEDC.NotesAPI.DataAccess.Interfaces.IRepository;

namespace SEDC.NotesAPI.DataAccess.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByUsername(string username);
        User LoginUser(string username, string password);
    }
}
