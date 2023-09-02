using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CRUDApp.Models;
using System.Linq;

namespace CRUDApp.Repository
{
    public class BookRepository
    {
        private SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add Book details
        public bool AddBook(Book obj)
        {

            connection();
            SqlCommand com = new SqlCommand("AddNewBookDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Title", obj.Title);
            com.Parameters.AddWithValue("@Author", obj.Author);
            com.Parameters.AddWithValue("@Category", obj.Category);
            com.Parameters.AddWithValue("@Publisher", obj.Publisher);
            com.Parameters.AddWithValue("@Pages", obj.Pages);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }
        //To view book details with generic list 
        public List<Book> GetAllBooks()
        {
            connection();
            List<Book> BookList = new List<Book>();
            SqlCommand com = new SqlCommand("InsertTableRecord", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            //Bind Book generic list using LINQ 
            BookList = (from DataRow dr in dt.Rows

                       select new Book()
                       {
                           Title = Convert.ToString(dr["Title"]),
                           Author = Convert.ToString(dr["Author"]),
                           Category = Convert.ToString(dr["Category"]),
                           Publisher = Convert.ToString(dr["Publisher"]),
                           Pages = Convert.ToInt32(dr["Pages"])
                       }).ToList();


            return BookList;


        }
        //To Update Book details
        public bool UpdateBook(Book obj)
        {

            connection();
            SqlCommand com = new SqlCommand("UpdateTableRecord", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", obj.Id);
            com.Parameters.AddWithValue("@Title", obj.Title);
            com.Parameters.AddWithValue("@Author", obj.Author);
            com.Parameters.AddWithValue("@Category", obj.Category);
            com.Parameters.AddWithValue("@Publisher", obj.Publisher);
            com.Parameters.AddWithValue("@Pages", obj.Pages);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }
        //To delete Book details
        public bool DeleteBook(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("DeleteTableRecordById", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", Id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
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
}