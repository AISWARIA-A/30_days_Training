using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using WebApplicationCRUD.Models;

namespace WebApplicationCRUD.Repository
{
    public class BookRepository
    {
        private SqlConnection connection;

        // To handle connections
        public void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["databaseConnection"].ToString();
            connection = new SqlConnection(connectionString);
        }

        //To add book details
        public bool AddBooks(Book book)
        {
            int id = 0;
            Connection();
            SqlCommand command = new SqlCommand("InsertBook", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Title", book.Title);
            command.Parameters.AddWithValue("@Author", book.Author);
            command.Parameters.AddWithValue("@Genre", book.Genre);
            command.Parameters.AddWithValue("@Description", book.Description);
            command.Parameters.AddWithValue("@Cover", book.Cover);

            connection.Open();
            id = command.ExecuteNonQuery();
            connection.Close();

            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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
                booksList.Add(
                    new Book
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Title = Convert.ToString(row["Title"]),
                        Author = Convert.ToString(row["Author"]),
                        Genre = Convert.ToString(row["Genre"]),
                        Description = Convert.ToString(row["Description"]),
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

            if(i >= 1)
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
            if(i >= 1)
            {
                return true;
            }
            else { return false; }
        }
    }
}