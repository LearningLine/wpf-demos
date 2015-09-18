using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using QAndADataAccess;
using QAndAModel;
using System.Data.SqlClient;

namespace QAndADataAccessDAO
{
    public class QuestionDataAccessDAO : IQuestionDataAccess
    {
        private string _connectionString;
        public QuestionDataAccessDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Question GetQuestion(int id)
        {
            int userid;
            string title;
            string message;
            User user;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                using(SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "select * from Questions where id=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if(!rdr.Read())
                    {
                        throw new Exception();
                    }
                    userid = rdr.GetInt32(rdr.GetOrdinal("userid"));
                    title = rdr.GetString(rdr.GetOrdinal("Title"));
                    message = rdr.GetString(rdr.GetOrdinal("Message"));
                    rdr.Close();   
                }
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from Users where id=@id";
                    cmd.Parameters.AddWithValue("@id", userid);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (!rdr.Read())
                    {
                        throw new Exception();
                    }
                    user = new User {Name = rdr["name"].ToString(), Email = rdr["email"].ToString()};
                }
            }

            return new NormalRatedQuestion(user) {Title = title, Message = message, Id = id};
        }
    }
}
