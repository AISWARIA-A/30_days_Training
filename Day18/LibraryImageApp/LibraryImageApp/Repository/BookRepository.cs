using LibraryImageApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace LibraryImageApp.Repository
{
    public class BookRepository
    {
        private SqlConnection connection;

        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["databaseConnection"].ToString();
            connection = new SqlConnection(connectionString);
        }

        //To insert book details
        public bool AddBooks(Book book, HttpPostedFileBase image)
        {
            Connection();
            SqlCommand command = new SqlCommand("SPI_InsertABook", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Title", book.Title);
            command.Parameters.AddWithValue("@Author", book.Author);
            command.Parameters.AddWithValue("@Category", book.Category);
            byte[] Photobyte = ConvertToBytes(image);
            command.Parameters.AddWithValue("@Cover", Photobyte);

            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i >= 0)
            {
                return true;
            }
            else { return false; }
        }

        //To get all book details

        public List<Book> GetAllBooks()
        {
            Connection();
            List<Book> bookList = new List<Book>();
            SqlCommand command = new SqlCommand("SPS_GetBooks", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            connection.Open();
            adapter.Fill(dataTable);
            connection.Close();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                // Assuming you have a column named "Cover" in your database to store image bytes.
                byte[] coverBytes = (byte[])dataRow["Cover"];

                bookList.Add(new Book
                {
                    Title = Convert.ToString(dataRow["Title"]),
                    Author = Convert.ToString(dataRow["Author"]),
                    Category = Convert.ToString(dataRow["Category"]),
                    // Set the Cover property in your Book model with image bytes.
                    Cover = coverBytes
                });
            }

            return bookList;
        }


        ///To edit book details

        public bool EditDetails(Book book)
        {
            Connection();
            SqlCommand command = new SqlCommand("SPU_UpdateBook", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Title", book.Title);
            command.Parameters.AddWithValue("@Author", book.Author);
            command.Parameters.AddWithValue("@Category", book.Category);
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

        /// <summary>
        /// To delete book details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public bool DeleteDetails(int id)
        {
            Connection();
            SqlCommand command = new SqlCommand("SPD_DeleteBook", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);

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