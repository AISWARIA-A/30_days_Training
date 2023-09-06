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
        public ActionResult AddDetails(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpPostedFileBase image = Request.Files["CoverImage"];

                    if (image != null && image.ContentLength > 0)
                    {
                        using (var binaryReader = new BinaryReader(image.InputStream))
                        {
                            book.Cover = binaryReader.ReadBytes(image.ContentLength);
                        }

                        if (bookRepository.AddBooks(book, image))
                        {
                            ViewBag.Message = "Book details added successfully";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Cover", "Please select a valid cover image.");
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
    }
}