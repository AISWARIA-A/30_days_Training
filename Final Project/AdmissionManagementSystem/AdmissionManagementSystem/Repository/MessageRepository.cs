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

        /// <summary>
        /// To create contact us messages
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
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
        /// <summary>
        /// To get all messages
        /// </summary>
        /// <returns></returns>
        public List<Message> GetAllMessages()
        {
            Connection();
            List<Message> messageList = new List<Message>();
            SqlCommand command = new SqlCommand("SPS_GetAllMessages", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            connection.Open();
            adapter.Fill(dataTable);
            connection.Close();

            foreach (DataRow dataRow in dataTable.Rows)
                messageList.Add(new Message
                {
                    MessageID = Convert.ToInt32(dataRow["MessageID"]),
                    Name = Convert.ToString(dataRow["Name"]),
                    Email = Convert.ToString(dataRow["Email"]),
                    Subject = Convert.ToString(dataRow["Subject"]),
                    MessageText = Convert.ToString(dataRow["MessageText"]),
                    DateTime = Convert.ToDateTime(dataRow["DateTime"])
                });
            return messageList;
        }

        public Message GetMessageById(int messageId)
        {
            Message message = null;
            Connection();

            using (SqlCommand command = new SqlCommand("SPS_GetMessageById", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MessageID", messageId);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        message = new Message
                        {
                            MessageID = Convert.ToInt32(reader["MessageID"]),
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString(),
                            Subject = reader["Subject"].ToString(),
                            MessageText = reader["MessageText"].ToString()
                    };
                    }
                }

                connection.Close();
            }

            return message;
        }
        /// <summary>
        /// Delete message by id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteMessageById(int id)
        {
            Connection();
            connection.Open();

            using (SqlCommand command = new SqlCommand("SPD_DeleteMessageById", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MessageID", id);

                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }
}