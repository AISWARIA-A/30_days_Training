using AdmissionManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdmissionManagementSystem.Repository
{
    public class LoginRepository
    {
        private SqlConnection connection;

        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["databaseConnection"].ToString();
            connection = new SqlConnection(connectionString);
        }

        public int AuthenticateAdmin(Login login)
        {
            Connection();
            connection.Open();

            using (SqlCommand command = new SqlCommand("SPI_AuthenticateAdmin", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Username", login.Username);
                command.Parameters.AddWithValue("@Password", login.Password);

                int adminId = (int)command.ExecuteScalar();

                connection.Close();
                return adminId;
            }
        }



        public int AuthenticateStudent(Login login)
        {
           
            Connection ();
            connection.Open();

            using (SqlCommand command = new SqlCommand("SPI_AuthenticateStudent", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Username", login.Username);
                command.Parameters.AddWithValue("@Password", login.Password);

                int studentId = (int)command.ExecuteScalar();

                connection.Close();

                return studentId;
            }
            
        }
    }
}