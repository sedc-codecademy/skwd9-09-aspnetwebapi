using Microsoft.Data.SqlClient;
using SEDC.NotesApp.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesApp.DataAccess.ADONET
{
    public class UserRepositoryADO : IRepository<User>
    {
        private readonly string _connectionString;

        public UserRepositoryADO(string connectionString)
        {
            _connectionString = connectionString;
        }


        public void Add(User entity)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = $@"INSERT INTO Users(Username, Firstname, LastName, Password) 
                                 VALUES ('{entity.Username}', '{entity.Firstname}', '{entity.LastName}', '{entity.Password}')";

            cmd.ExecuteNonQuery();
            connection.Close();
        }
        

        public List<User> GetAll()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = "SELECT * from Users";

            SqlDataReader dr = cmd.ExecuteReader();

            List<User> users = new List<User>();

            while (dr.Read())
            {
                // Third Approach
                users.Add(new User
                {
                    Id = (int)dr["Id"],
                    Username = (string)dr["Username"],
                    Firstname = (string)dr["Firstname"],
                    LastName = (string)dr["LastName"],
                    Password = (string)dr["Password"],
                });
            }

            connection.Close();

            return users;
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
