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
        /// <summary>
        /// connection 
        /// </summary>
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["databaseConnection"].ToString();
            connection = new SqlConnection(connectionString);
        }
        /// <summary>
        /// To add admin
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public bool AddAdmin(Admin admin)
        {
            try {
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

                return i >= 0;
            }
            finally
            {
                connection.Close();
            }
            
        }
        /// <summary>
        /// Change admin password
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="changePassword"></param>
        /// <returns></returns>
        public int ChangePassword(int adminId, ChangePassword changePassword)
        {
            try
            {
                Connection();
                SqlCommand command = new SqlCommand("SPU_ChangeAdminPassword", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AdminID", adminId);
                command.Parameters.AddWithValue("@OldPassword", changePassword.OldPassword);
                command.Parameters.AddWithValue("@NewPassword", changePassword.NewPassword);

                connection.Open();
                int result = (int)command.ExecuteScalar();
                connection.Close();
                return result;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}