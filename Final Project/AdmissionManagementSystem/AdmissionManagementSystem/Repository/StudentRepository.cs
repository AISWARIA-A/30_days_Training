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
    public class StudentRepository
    {
        private SqlConnection connection;

        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["databaseConnection"].ToString();
            connection = new SqlConnection(connectionString);
        }

        public bool AddStudent(Student student)
        {
            Connection();
            SqlCommand command = new SqlCommand("SPI_InsertStudent", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@FirstName", student.FirstName);
            command.Parameters.AddWithValue("@LastName", student.LastName);
            command.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
            command.Parameters.AddWithValue("@Gender", student.Gender);
            command.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);
            command.Parameters.AddWithValue("@EmailAddress", student.EmailAddress);
            command.Parameters.AddWithValue("@Address", student.Address);
            command.Parameters.AddWithValue("@State", student.State);
            command.Parameters.AddWithValue("@City", student.City);
            command.Parameters.AddWithValue("@Username", student.Username);
            command.Parameters.AddWithValue("@Password", student.Password);

            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();

            return i >= 0;
        }

    }
}