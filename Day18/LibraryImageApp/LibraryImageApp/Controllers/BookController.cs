using LibraryImageApp.Models;
using LibraryImageApp.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryImageApp.Controllers
{
    public class BookController : Controller
    {
        BookRepository bookRepository = new BookRepository();
        // GET: Book
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(bookRepository.GetAllBooks());
        }

        public ActionResult AddDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDetails(Book book, HttpPostedFileBase image)
        {
            BookRepository bookRepository = new BookRepository();
            bookRepository.AddBooks(book, image);
            return RedirectToAction("Index");
        }


        public ActionResult EditDetails(int? id)
        {
            return View(bookRepository.GetAllBooks().Find(book => book.Id == id));
        }

        [HttpPost]
        public ActionResult EditDetails(int id, Book book)
        {
            try
            {
                bookRepository.EditDetails(book);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult DeleteDetails(int id)
        {
            if (bookRepository.DeleteDetails(id))
            {
                TempData["SuccessMessage"] = "Book details deleted successfully";
            }
            else
            {
                TempData["ErrorMessage"] = "Unable to delete details";
            }
            return RedirectToAction("Index");

        }

        private bool IsImage(HttpPostedFileBase Photo)
        {
            if (Photo != null && Photo.ContentLength > 0)
            {
                string[] allowedImageTypes = { "image/jpeg", "image/png", "image/gif" };
                string contentType = Photo.ContentType;

                return allowedImageTypes.Contains(contentType);
            }
            return false;
        }
    }
}