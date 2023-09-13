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
    public class AdminRepository
    {
        private SqlConnection connection;

        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["databaseConnection"].ToString();
            connection = new SqlConnection(connectionString);
        }

        public bool AddAdmin(Admin admin)
        {
            Connection();
            SqlCommand command = new SqlCommand("SPI_InsertAdmin", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@FirstName", admin.FirstName);
            command.Parameters.AddWithValue("@LastName", admin.LastName);
            command.Parameters.AddWithValue("@EmailAddress", admin.EmailAddress);
            command.Parameters.AddWithValue("@Username", admin.Username);
            command.Parameters.AddWithValue("@Password", admin.Password);

            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();

            return i >= 0;
        }

    }
}