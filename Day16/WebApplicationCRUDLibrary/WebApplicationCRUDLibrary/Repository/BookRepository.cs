using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebApplicationCRUDLibrary.Models;
using System.IO;

namespace WebApplicationCRUDLibrary.Repository
{
    public class BookRepository
    {
        private SqlConnection connection;

        // To handle connections
        public void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
            connection = new SqlConnection(connectionString);
        }

        //To add book details
        public bool AddBooks(Book book, HttpPostedFileBase coverImage)
        {
            int id = 0;
            Connection();
            SqlCommand command = new SqlCommand("InsertBook", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Title", book.Title);
            command.Parameters.AddWithValue("@Author", book.Author);
            command.Parameters.AddWithValue("@Genre", book.Genre);
            command.Parameters.AddWithValue("@Description", book.Description);

            if (coverImage != null && coverImage.ContentLength > 0)
            {
                using (var binaryReader = new BinaryReader(coverImage.InputStream))
                {
                    book.Cover = binaryReader.ReadBytes(coverImage.ContentLength);
                }
            }

            // Converting the Cover byte array to a SqlParameter with SqlDbType.VarBinary
            SqlParameter paramCover = new SqlParameter("@Cover", SqlDbType.VarBinary)
            {
                Value = book.Cover
            };
            command.Parameters.Add(paramCover);

            connection.Open();
            id = command.ExecuteNonQuery();
            connection.Close();

            return id > 0;
        }




        //To get all book details
        public List<Book> GetAllBooks()
        {
            Connection();
            List<Book> booksList = new List<Book>();
            SqlCommand command = new SqlCommand("GetAllBooks", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            connection.Open();
            adapter.Fill(dataTable);
            connection.Close();

            foreach (DataRow row in dataTable.Rows)
            {
                byte[] coverImageBytes = row["Cover"] as byte[]; // Retrieve the cover image as byte array

                booksList.Add(
                    new Book
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Title = Convert.ToString(row["Title"]),
                        Author = Convert.ToString(row["Author"]),
                        Genre = Convert.ToString(row["Genre"]),
                        Description = Convert.ToString(row["Description"]),
                        // Set the Cover property with the retrieved byte array
                        Cover = coverImageBytes
                    });
            }
            return booksList;
        }


        //To edit book details
        public bool EditDetails(Book book)
        {
            Connection();
            SqlCommand command = new SqlCommand("Updatebook", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", book.Id);
            command.Parameters.AddWithValue("@Title", book.Title);
            command.Parameters.AddWithValue("@Author", book.Author);
            command.Parameters.AddWithValue("@Genre", book.Genre);
            command.Parameters.AddWithValue("@Description", book.Description);
            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();

            if (i >= 1)
            {
                return true;
            }
            else { return false; }
        }

        //To delete a Book
        public bool DeleteDetails(int id)
        {
            Connection();
            SqlCommand command = new SqlCommand("DeleteBookById", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);

            connection.Open();
            int i = command.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            else { return false; }
        }

    }
}