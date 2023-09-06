using CRUDOperations.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDOperations.Models;

namespace CRUDOperations.Controllers
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
                    if (bookRepository.AddDetails(book))
                    {
                        ViewBag.Message = "Book details added successfully";
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