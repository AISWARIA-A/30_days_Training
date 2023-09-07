using CRUDOperations.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUDOperations.Repository
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
        public bool AddDetails(Book book)
        {
            Connection();
            SqlCommand command = new SqlCommand("SPI_InsertBook", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Title", book.Title);
            command.Parameters.AddWithValue("@Author", book.Author);
            command.Parameters.AddWithValue("@Category", book.Category);
            command.Parameters.AddWithValue("@Description", book.Description);
            command.Parameters.AddWithValue("@Price", book.Price);

            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if(i >= 0) 
            {
                return true;
            }
            else { return false; }
        }

        //To get all book details

        public List<Book> GetAllBooks()
        {
            Connection ();
            List<Book> bookList = new List<Book>();
            SqlCommand command = new SqlCommand("SPS_GetAllBooks", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            connection.Open ();
            adapter.Fill (dataTable);
            connection.Close ();

            foreach (DataRow dataRow in dataTable.Rows)
                bookList.Add(new Book
                {
                   
                    Title = Convert.ToString(dataRow["Title"]),
                    Author = Convert.ToString(dataRow["Author"]),
                    Category = Convert.ToString(dataRow["Category"]),
                    Description = Convert.ToString(dataRow["Description"]),
                    Price = Convert.ToInt32(dataRow["Price"])
                });
            return bookList;
        }

        //To edit book details

        public bool EditDetails(Book book)
        {
            Connection();
            SqlCommand command = new SqlCommand("SPU_EditBook", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Title", book.Title);
            command.Parameters.AddWithValue("@Author", book.Author);
            command.Parameters.AddWithValue("@Category", book.Category);
            command.Parameters.AddWithValue("@Description", book.Description);
            command.Parameters.AddWithValue("@Price", book.Price);

            connection.Open ();
            int i = command.ExecuteNonQuery();
            connection.Close ();
            if(i >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       /// <summary>
       /// To delete book details by id
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>

        public bool DeleteDetails(int id)
        {
            Connection ();
            SqlCommand command = new SqlCommand("SPD_DeleteBookById", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);

            connection.Open ();
            int i = command.ExecuteNonQuery();
            connection.Close ();
            if(i >= 0)
            {
                return true;
            }
            else { return false;}
        }


    }
}