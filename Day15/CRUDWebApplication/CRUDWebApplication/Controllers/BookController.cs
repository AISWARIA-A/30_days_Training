using CRUDWebApplication.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDWebApplication.Controllers
{

    public class BookController : Controller
    {

        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Aiswaria A\\Documents\\LIBRARY.mdf\";Integrated Security=True;Connect Timeout=30";

        // GET: Book
        public ActionResult Index()
        {
            List<Book> books = new List<Book>();

            // Database interaction using ADO.NET to call the stored procedure for retrieving a list of books
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllBooks", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Book book = new Book
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"].ToString(),
                        Author = reader["Author"].ToString(),
                        Genre = reader["Genre"].ToString(),
                        Description = reader["Description"].ToString()
                        // Be sure to handle CoverImage appropriately based on your database design
                    };
                    books.Add(book);
                }
            }

            return View(books);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            Book book = null;

            // Database interaction using ADO.NET to call the stored procedure for retrieving a book by ID
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetBookById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    book = new Book
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"].ToString(),
                        Author = reader["Author"].ToString(),
                        Genre = reader["Genre"].ToString(),
                        Description = reader["Description"].ToString()
                        // Be sure to handle CoverImage appropriately based on your database design
                    };
                }
            }

            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book, HttpPostedFileBase coverImage)
        {
            if (ModelState.IsValid)
            {
                if (coverImage != null && coverImage.ContentLength > 0)
                {
                    using (var binaryReader = new BinaryReader(coverImage.InputStream))
                    {
                        book.CoverImage = binaryReader.ReadBytes(coverImage.ContentLength);
                    }

                }

                // Database interaction using ADO.NET to call the stored procedure for creating a new book
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("InsertBook", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@Genre", book.Genre);
                    command.Parameters.AddWithValue("@Description", book.Description);
                    command.Parameters.AddWithValue("@CoverImage", book.CoverImage);
                    command.ExecuteNonQuery();
                }

                // Redirect to the book list view or a success page
                return RedirectToAction("Index");
            }

            return View(book);
        }


        public ActionResult Edit(int id)
        {
            Book book = null;

            // Database interaction using ADO.NET to call the stored procedure for retrieving a book by ID
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetBookById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    book = new Book
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"].ToString(),
                        Author = reader["Author"].ToString(),
                        Genre = reader["Genre"].ToString(),
                        Description = reader["Description"].ToString()
                        // Be sure to handle CoverImage appropriately based on your database design
                    };
                }
            }

            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                // Database interaction using ADO.NET to call the stored procedure for updating the book
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UpdateBook", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", book.Id);
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@Genre", book.Genre);
                    command.Parameters.AddWithValue("@Description", book.Description);
                    // Add CoverImage handling if necessary
                    command.ExecuteNonQuery();
                }

                // Redirect to the book list view or a success page
                return RedirectToAction("Index");
            }

            return View(book);
        }



        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            Book book = null;

            // Database interaction using ADO.NET to call the stored procedure for retrieving a book by ID for deletion confirmation
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetBookById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    book = new Book
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"].ToString()
                    };
                }
            }

            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Database interaction using ADO.NET to call the stored procedure for deleting the book by ID
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DeleteBook", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }

            // Redirect to the book list view or a success page
            return RedirectToAction("Index");
        }

    }
}
