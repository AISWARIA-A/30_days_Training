using AdmissionManagementSystem.Common;
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
        Password EncryptData = new Password();
        /// <summary>
        /// connection
        /// </summary>
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["databaseConnection"].ToString();
            connection = new SqlConnection(connectionString);
        }
        /// <summary>
        /// Admin authenticattion
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public int AuthenticateAdmin(Login login)
        {
            try
            {
                Connection();
                connection.Open();

                using (SqlCommand command = new SqlCommand("SPI_AuthenticateAdmin", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Username", login.Username);
                    command.Parameters.AddWithValue("@Password", EncryptData.Encode(login.Password));

                    int adminId = (int)command.ExecuteScalar();

                    connection.Close();
                    return adminId;
                }
            }
            finally { connection.Close(); }
        }
        /// <summary>
        /// To authenticate student login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public int AuthenticateStudent(Login login)
        {
            try
            {
                Connection();
                connection.Open();

                using (SqlCommand command = new SqlCommand("SPI_AuthenticateStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Username", login.Username);
                    command.Parameters.AddWithValue("@Password", EncryptData.Encode(login.Password));

                    int studentId = (int)command.ExecuteScalar();

                    connection.Close();

                    return studentId;
                }
            }
            finally {
                connection.Close();
            }
        }
    }
}