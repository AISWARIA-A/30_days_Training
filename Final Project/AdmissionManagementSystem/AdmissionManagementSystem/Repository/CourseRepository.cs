﻿using AdmissionManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace AdmissionManagementSystem.Repository
{
    public class CourseRepository
    {
        private SqlConnection connection;

        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["databaseConnection"].ToString();
            connection = new SqlConnection(connectionString);
        }
        /// <summary>
        /// To add a course
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public bool AddCourses(Course course)
        {
            try
            {
                Connection();
                SqlCommand command = new SqlCommand("SPI_InsertCourse", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CourseName", course.CourseName);
                command.Parameters.AddWithValue("@CourseDescription", course.CourseDescription);
                command.Parameters.AddWithValue("@FormOpenDate", course.FormOpenDate);
                command.Parameters.AddWithValue("@FormCloseDate", course.FormCloseDate);
                command.Parameters.AddWithValue("@CourseCapacity", course.CourseCapacity);
                command.Parameters.AddWithValue("@CourseStatus", course.CourseStatus);
                connection.Open();
                int i = command.ExecuteNonQuery();
                if (i >= 0)
                {
                    return true;
                }
                else { return false; }
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// To get all course details
        /// </summary>
        /// <returns></returns>
        public List<Course> GetAllCourses()
        {
            try
            {
                Connection();
                List<Course> courseList = new List<Course>();
                SqlCommand command = new SqlCommand("SPS_GetAllCourses", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                connection.Open();
                adapter.Fill(dataTable);

                foreach (DataRow dataRow in dataTable.Rows)
                    courseList.Add(new Course
                    {
                        CourseID = Convert.ToInt32(dataRow["CourseID"]),
                        CourseName = Convert.ToString(dataRow["CourseName"]),
                        CourseDescription = Convert.ToString(dataRow["CourseDescription"]),
                        FormOpenDate = Convert.ToDateTime(dataRow["FormOpenDate"]),
                        FormCloseDate = Convert.ToDateTime(dataRow["FormCloseDate"]),
                        CourseCapacity = Convert.ToInt32(dataRow["CourseCapacity"]),
                        CourseStatus = Convert.ToString(dataRow["CourseStatus"])
                    });
                return courseList;
            }
            finally { connection.Close(); }
        }
        /// <summary>
        /// To get course by Id
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public Course GetCourseById(int courseId)
        {
            try
            {
                Course course = null;
                Connection();

                using (SqlCommand command = new SqlCommand("SPS_GetCourseById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CourseID", courseId);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            course = new Course
                            {
                                CourseID = Convert.ToInt32(reader["CourseID"]),
                                CourseName = reader["CourseName"].ToString(),
                                CourseDescription = reader["CourseDescription"].ToString(),
                                FormOpenDate = Convert.ToDateTime(reader["FormOpenDate"]),
                                FormCloseDate = Convert.ToDateTime(reader["FormCloseDate"]),
                                CourseCapacity = Convert.ToInt32(reader["CourseCapacity"]),
                                CourseStatus = reader["CourseStatus"].ToString()
                            };
                        }
                    }
                }

                return course;
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// To edit a course
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public bool EditCourse(Course course)
        {
            try
            {
                Connection();
                SqlCommand command = new SqlCommand("SPU_UpdateCourse", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@CourseName", course.CourseName);
                command.Parameters.AddWithValue("@CourseDescription", course.CourseDescription);
                command.Parameters.AddWithValue("@FormOpenDate", course.FormOpenDate);
                command.Parameters.AddWithValue("@FormCloseDate", course.FormCloseDate);
                command.Parameters.AddWithValue("@CourseCapacity", course.CourseCapacity);
                command.Parameters.AddWithValue("@CourseStatus", course.CourseStatus);
                command.Parameters.AddWithValue("@CourseID", course.CourseID);

                connection.Open();
                int i = command.ExecuteNonQuery();
                connection.Close();
                if (i >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally { connection.Close(); }
        }
        /// <summary>
        /// To delete a course by id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCourseById(int id)
        {
            try
            {
                Connection();
                connection.Open();

                using (SqlCommand command = new SqlCommand("SPD_DeleteCourseById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CourseID", id);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            finally { 
                connection.Close();
            }
        }
        /// <summary>
        /// To view list of students applied for each course
        /// </summary>
        /// <param name="courseID"></param>
        /// <returns></returns>
        public List<AppliedStudent> GetAppliedStudentsByCourseID(int courseID)
        {
            try
            {
                List<AppliedStudent> appliedStudents = new List<AppliedStudent>();

                Connection();
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SPS_AppliedStudents", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CourseID", courseID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AppliedStudent student = new AppliedStudent
                                {
                                    ApplicationID = (int)reader["ApplicationID"],
                                    StudentName = reader["StudentName"].ToString(),
                                    ApplicationDate = (DateTime)reader["ApplicationDate"],
                                    Status = reader["Status"].ToString(),
                                    StudentID = (int)reader["StudentID"]
                                };

                                appliedStudents.Add(student);
                            }
                        }
                        connection.Close();
                    }
                }

                return appliedStudents;
            }
            finally { connection.Close(); }
        }
        public List<AppliedStudent> GetAppliedStudentsByCourseIDs(int courseID)
        {
            try
            {
                List<AppliedStudent> appliedStudents = new List<AppliedStudent>();

                Connection();
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SPS_AppliedStudentsWithSeatLeft", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CourseID", courseID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AppliedStudent student = new AppliedStudent
                                {
                                    ApplicationID = (int)reader["ApplicationID"],
                                    StudentName = reader["StudentName"].ToString(),
                                    ApplicationDate = (DateTime)reader["ApplicationDate"],
                                    Status = reader["Status"].ToString(),
                                    StudentID = (int)reader["StudentID"],
                                    SeatsLeft = (int)reader["SeatsLeft"]
                                };

                                appliedStudents.Add(student);
                            }
                        }
                        connection.Close();
                    }
                }

                return appliedStudents;
            }
            finally { connection.Close(); }
        }

        /// <summary>
        /// To reject an application
        /// </summary>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        public bool RejectStudent(int applicationId)
        {
            try
            {
                Connection();

                using (SqlCommand command = new SqlCommand("SPU_RejectStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ApplicationID", applicationId);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    return rowsAffected > 0;
                }
            }
            finally { connection.Close(); }
        }
        /// <summary>
        /// To accept an application
        /// </summary>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        public bool AcceptStudent(int applicationId)
        {
            try
            {
                Connection();

                using (SqlCommand command = new SqlCommand("SPU_AcceptStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ApplicationID", applicationId);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    connection.Close();

                    return result > 0;
                }
            }
            finally { connection.Close(); }
        }

    }
}