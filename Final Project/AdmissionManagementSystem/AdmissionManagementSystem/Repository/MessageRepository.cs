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
    public class MessageRepository
    {
        private SqlConnection connection;

        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["databaseConnection"].ToString();
            connection = new SqlConnection(connectionString);
        }


        public bool AddMessages(Message message)
        {
            Connection();
            SqlCommand command = new SqlCommand("SPI_InsertContactMessage", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", message.Name);
            command.Parameters.AddWithValue("@Email", message.Email);
            command.Parameters.AddWithValue("@Subject", message.Subject);
            command.Parameters.AddWithValue("@MessageText", message.MessageText);
            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i >= 0)
            {
                return true;
            }
            else { return false; }
        }
    }
}