using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using Model;
namespace ChatServer
{
    class DatabaseWrapper
    {
        private String connectionString;
        private SqlConnection sqlConnection;

        public DatabaseWrapper()
        {
            connectionString = "Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=chatsystem;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
        }

        public Boolean checkUser(User user)
        {
            SqlDataReader reader = null;

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select * from users WHERE name=" + user.name + " AND password=" + user.password, sqlConnection);
            reader = cmd.ExecuteReader();

            Boolean result = reader.HasRows;

            if (reader != null)
            {
                reader.Close();
            }

            if (sqlConnection != null)
            {
                sqlConnection.Close();
            }

            return result;
        }
    }
}
