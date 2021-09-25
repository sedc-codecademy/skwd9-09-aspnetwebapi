using Microsoft.Data.SqlClient;
using SEDC.NotesApp.DataModels;
using System.Collections.Generic;

namespace SEDC.NotesApp.DataAccess.ADONET
{
    public class NoteRepositoryADO : IRepository<Note>
    {
        private readonly string _connectionString;

        public NoteRepositoryADO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Note> GetAll()
        {
            // 1. Create new connection providing the connection string
            SqlConnection connection = new SqlConnection(_connectionString);

            // 2. Open the connection
            connection.Open();

            // 3. Create new SQL Command and add the correct connection to it
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            // 4. Give the command a text (SQL query)
            cmd.CommandText = "SELECT * from Notes";

            // 5. Execute the previous command by using the ExecuteReader() method.
            // Reads data from a data source (table in our example)
            SqlDataReader dr = cmd.ExecuteReader();

            List<Note> notes = new List<Note>();

            while(dr.Read())
            {
                // First Approach
                //notes.Add(new Note
                //{
                //    Id = dr.GetInt32(0),
                //    Text = dr.GetString(1),
                //    Color = dr.GetString(2),
                //    Tag = dr.GetInt32(3),
                //    UserId = dr.GetInt32(4)
                //});

                // Second Approach
                //notes.Add(new Note
                //{
                //    Id = dr.GetFieldValue<int>(0),
                //    Text = dr.GetFieldValue<string>(1),
                //    Color = dr.GetFieldValue<string>(2),
                //    Tag = dr.GetFieldValue<int>(3),
                //    UserId = dr.GetFieldValue<int>(4)
                //});

                // Third Approach
                notes.Add(new Note
                {
                    Id = (int)dr["Id"],
                    Text = (string)dr["Text"],
                    Color = (string)dr["Color"],
                    Tag = (int)dr["Tag"],
                    UserId = (int)dr["UserId"],
                });

            }

            connection.Close();

            return notes;
        }


        public void Add(Note entity)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            //cmd.CommandText = $@"INSERT INTO Notes (Text, Color, Tag, UserId, DateCreated)
            //                     VALUES('{entity.Text}', '{entity.Color}', {entity.Tag}, {entity.UserId}, '{entity.DateCreated}')";

            cmd.CommandText = $@"INSERT INTO Notes (Text, Color, Tag, UserId, DateCreated)
                                 VALUES(@text, @color, @tag, @userId, @dateCreated)";

            cmd.Parameters.AddWithValue("@text", entity.Text);
            cmd.Parameters.AddWithValue("@color", entity.Color);
            cmd.Parameters.AddWithValue("@tag", entity.Tag);
            cmd.Parameters.AddWithValue("@userId", entity.UserId);
            cmd.Parameters.AddWithValue("@dateCreated", entity.DateCreated);

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void Delete(Note entity)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = $"DELETE FROM Notes WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void Update(Note entity)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = $"UPDATE Notes " +
                              $"SET Text = @text, Color = @color, Tag = @tag, UserId = @userId, DateCreated = @dateCreated " +
                              $"WHERE Id = @id";

            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@text", entity.Text);
            cmd.Parameters.AddWithValue("@color", entity.Color);
            cmd.Parameters.AddWithValue("@tag", entity.Tag);
            cmd.Parameters.AddWithValue("@userId", entity.UserId);
            cmd.Parameters.AddWithValue("@dateCreated", entity.DateCreated);

            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
