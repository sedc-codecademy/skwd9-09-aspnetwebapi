using SEDC.NotesAPI.DataAccess.Interfaces;
using SEDC.NotesAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Tests
{
    public class FakeUserRepository : IUserRepository
    {
        private List<User> users;
        public FakeUserRepository()
        {
            // We create an instance of the MD5CryptoServiceProvider that will help us create the hash
            var md5 = new MD5CryptoServiceProvider();
            // We create the hash from the password
            var md5Data = md5.ComputeHash(Encoding.ASCII.GetBytes("netikazuvam123"));
            // We get the hash string
            var hashedPassword = Encoding.ASCII.GetString(md5Data);

            users = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Bobsky",
                    Username = "bob123",
                    Password = hashedPassword
                }
            };
        }
        public void Add(User entity)
        {
            users.Add(entity);
        }

        public void Delete(User entity)
        {
            users.Remove(entity);
        }

        public List<User> GetAll()
        {
            return users;
        }

        public User GetById(int id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }

        public User GetUserByUsername(string username)
        {
            return users.FirstOrDefault(x => x.Username == username);
        }

        public User LoginUser(string username, string password)
        {
            return users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower()
            && x.Password == password);
        }

        public void Update(User entity)
        {
            users[users.IndexOf(entity)] = entity;
        }
    }
}
