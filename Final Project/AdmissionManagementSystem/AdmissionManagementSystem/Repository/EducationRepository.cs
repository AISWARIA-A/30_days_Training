﻿using AdmissionManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdmissionManagementSystem.Repository
{
    public class EducationRepository
    {
        private SqlConnection connection;

        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["databaseConnection"].ToString();
            connection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// To insert education details
        /// </summary>
        /// <param name="education"></param>
        /// <param name="tenth"></param>
        /// <param name="plustwo"></param>
        /// <param name="degree"></param>
        /// <returns></returns>
        public bool Insert(EducationDetails education, HttpPostedFileBase tenth, HttpPostedFileBase plustwo, HttpPostedFileBase degree)
        {
            Connection();
            using (SqlCommand command = new SqlCommand("SPI_InsertEducation", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TenthSchool", education.TenthSchool);
                command.Parameters.AddWithValue("@TenthCGPA", education.TenthCGPA);
                byte[] Photobytes1 = ConvertToBytes(tenth);
                command.Parameters.AddWithValue("@TenthCertificate", Photobytes1);
                command.Parameters.AddWithValue("@PlusTwoSchool", education.PlusTwoSchool);
                command.Parameters.AddWithValue("@PlusTwoCGPA", education.PlusTwoCGPA);
                byte[] PhotoBytes2 = ConvertToBytes(plustwo);
                command.Parameters.AddWithValue("@PlusTwoCertificate", PhotoBytes2);
                command.Parameters.AddWithValue("@DegreeCollege", education.DegreeCollege);
                command.Parameters.AddWithValue("@DegreeCGPA", education.DegreeCGPA);
                command.Parameters.AddWithValue("@DegreeStream", education.DegreeStream);
                byte[] PhotoBytes3 = ConvertToBytes(degree);
                command.Parameters.AddWithValue("@DegreeCertificate", PhotoBytes3);
                connection.Open();
                int i = command.ExecuteNonQuery();
                connection.Close();
                if (i >= 1)
                {

                    return true;

                }
                else
                {

                    return false;
                }
            }
        }
        /// <summary>
        /// Byte converter
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        private byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            if (image != null)
            {
                byte[] imageBytes = new byte[image.ContentLength];
                image.InputStream.Read(imageBytes, 0, image.ContentLength);
                return imageBytes;
            }
            return null;
        }

        public List<EducationDetails> GetEducationDetails()
        {
            Connection();
            List<EducationDetails> List = new List<EducationDetails>();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SPS_EducationDetails";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dtable = new DataTable();

            connection.Open();
            adapter.Fill(dtable);
            connection.Close();

            foreach (DataRow row in dtable.Rows)
            {
                studentsList.Add(new EducationDetails
                {
                    StudentID = Convert.ToInt32(row["StudentID"]),
                    EducationID = Convert.ToInt32(row["EducationID"]),
                    TenthSchool = row["TenthSchool"].ToString(),
                    TenthCGPA = Convert.ToDecimal(row["TenthCGPA"]),
                    TenthCertificate = row["TenthCertificate"] as byte[],
                    PlusTwoSchool = row["PlusTwoSchool"].ToString(),
                    PlusTwoCGPA = Convert.ToDecimal(row["PlusTwoCGPA"]),
                    PlusTwoCertificate = row["PlusTwoCertificate"] as byte[],
                    DegreeCollege = row["DegreeCollege"].ToString(),
                    DegreeStream = row["DegreeStream"].ToString(),
                    DegreeCGPA = Convert.ToDecimal(row["DegreeCGPA"]),
                    DegreeCertificate = row["DegreeCertificate"] as byte[]

                });
            }

            return studentsList;
        }



        public EducationDetails GetEducationDetails(int studentId)
        {
            EducationDetails educationDetails = null;
            Connection();

            using (SqlCommand command = new SqlCommand("SPS_EducationDetails", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StudentID", studentId);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        educationDetails = new EducationDetails
                        {
                            StudentID = Convert.ToInt32(reader["StudentID"]),
                            EducationID = Convert.ToInt32(reader["EducationID"]),
                            TenthSchool = reader["TenthSchool"].ToString(),
                            TenthCGPA = Convert.ToDecimal(reader["TenthCGPA"]),
                            TenthCertificate = reader["TenthCertificate"] as byte[],
                            PlusTwoSchool = reader["PlusTwoSchool"].ToString(),
                            PlusTwoCGPA = Convert.ToDecimal(reader["PlusTwoCGPA"]),
                            PlusTwoCertificate = reader["PlusTwoCertificate"] as byte[],
                            DegreeCollege = reader["DegreeCollege"].ToString(),
                            DegreeStream = reader["DegreeStream"].ToString(),
                            DegreeCGPA = Convert.ToDecimal(reader["DegreeCGPA"]),
                            DegreeCertificate = reader["DegreeCertificate"] as byte[]
                        };
                    }
                }

                connection.Close();
            }

            return educationDetails;
        }

    }
}