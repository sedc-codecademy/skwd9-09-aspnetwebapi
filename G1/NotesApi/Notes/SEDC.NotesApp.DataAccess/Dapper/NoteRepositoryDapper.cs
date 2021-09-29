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
    public class NoteRepositoryDapper : IRepository<Note>
    {
        private readonly string _connectionString;
        private readonly SqlConnection _conn;

        public NoteRepositoryDapper(string connectionString)
        {
            _connectionString = connectionString;
            _conn = new SqlConnection(_connectionString);
        }
        public List<Note> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                List<Note> notes = conn.Query<Note>("SELECT * FROM Notes").ToList();
                return notes;
            }
        }

        public void Add(Note entity)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                conn.Insert(entity);
            }
        }

        public void Delete(Note entity)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                conn.Delete(entity);
            }
        }


        public void Update(Note entity)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                conn.Update(entity);
            }
        }

        // Complex query using dapper (Multiple queries)

        //public void MultipleQueryExample()
        //{
        //    using (var multi = _conn.QueryMultiple("SELECT * FROM Notes; SELECT * FROM Users;"))
        //    {
        //        List<Note> notes = new List<Note>();
        //        notes = multi.Read<Note>().ToList();

        //        List<User> users = multi.Read<User>().ToList();
        //    }
        //}
    }
}
