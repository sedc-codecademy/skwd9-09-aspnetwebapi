using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using SEDC.NotesApp.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.NotesApp.DataAccess.Dapper
{
    public class UserRepositoryDapper : IRepository<User>
    {
        private readonly string _connectionString;
        public UserRepositoryDapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(User entity)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                conn.Insert(entity);
            }
        }

        public void Delete(User entity)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                conn.Delete(entity);
            }
        }

        public List<User> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                List<User> users = conn.Query<User>("SELECT * FROM Users").ToList();
                return users;
            }
        }

        public void Update(User entity)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                conn.Update(entity);
            }
        }
    }
}
