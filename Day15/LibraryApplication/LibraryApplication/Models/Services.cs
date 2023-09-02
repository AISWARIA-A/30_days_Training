using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace LibraryApplication.Models
{
    public class Services
    {
        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        
        public bool Add(Book book)
        {
            SqlCommand cmd = new SqlCommand("InsertTableRecord",conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@title", book.Title);
            cmd.Parameters.AddWithValue("@author", book.Author);
            cmd.Parameters.AddWithValue("@category", book.Category);
            cmd.Parameters.AddWithValue("@publisher", book.Publisher);
            cmd.Parameters.AddWithValue("@pages", book.Pages);

            if(conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            int i = cmd.ExecuteNonQuery();
            conn.Close();
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