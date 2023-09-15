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
        /// <summary>
        /// Insert a student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
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
        /// <summary>
        /// To get all students
        /// </summary>
        /// <returns></returns>
        public List<Student> GetAllStudents()
        {
            Connection();
            List<Student> studentList = new List<Student>();
            SqlCommand command = new SqlCommand("SPS_GetAllStudents", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            connection.Open();
            adapter.Fill(dataTable);
            connection.Close();

            foreach (DataRow dataRow in dataTable.Rows)
                studentList.Add(new Student
                {
                    StudentID = Convert.ToInt32(dataRow["StudentId"]),
                    FirstName = Convert.ToString(dataRow["FirstName"]),
                    LastName = Convert.ToString(dataRow["LastName"]),
                    DateOfBirth = Convert.ToDateTime(dataRow["DateOfBirth"]),
                    Gender = Convert.ToString(dataRow["Gender"]),
                    PhoneNumber = Convert.ToString(dataRow["PhoneNumber"]),
                    EmailAddress = Convert.ToString(dataRow["EmailAddress"]),
                    Address = Convert.ToString(dataRow["Address"]),
                    State = Convert.ToString(dataRow["State"]),
                    City = Convert.ToString(dataRow["City"]),
                    Username = Convert.ToString(dataRow["Username"]),
                    Password = Convert.ToString(dataRow["Password"])
                }); 
            return studentList;
        }
        /// <summary>
        /// To get student details by id
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public Student GetStudentById(int studentId)
        {
            Student student = null;
            Connection();

            using (SqlCommand command = new SqlCommand("SPS_GetStudentById", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StudentID", studentId);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        student = new Student
                        {
                            StudentID = Convert.ToInt32(reader["StudentID"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                            Gender = reader["Gender"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            EmailAddress = reader["EmailAddress"].ToString(),
                            Address = reader["Address"].ToString(),
                            State = reader["State"].ToString(),
                            City = reader["City"].ToString(),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString()
                        };
                    }
                }

                connection.Close();
            }

            return student;
        }
        /// <summary>
        /// To delete a student account by id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteStudentById(int id)
        {
            Connection();
            connection.Open();

            using (SqlCommand command = new SqlCommand("SPD_DeleteStudentById", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StudentID", id);

                command.ExecuteNonQuery();
            }

            connection.Close();
        }

    }
}