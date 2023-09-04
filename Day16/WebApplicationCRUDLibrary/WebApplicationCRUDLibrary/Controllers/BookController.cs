using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationCRUDLibrary.Models;
using WebApplicationCRUDLibrary.Repository;

namespace WebApplicationCRUDLibrary.Controllers
{
    public class BookController : Controller
    {
        BookRepository bookRepository = new BookRepository();
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(bookRepository.GetAllBooks());
        }

        public ActionResult AddDetails()
        {
            return View();
        }

        //POST: Book/Create
        [HttpPost]
        public ActionResult AddDetails(Book book, HttpPostedFileBase Cover)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isInserted = bookRepository.AddBooks(book, Cover);
                    if (isInserted)
                    {
                        TempData["SuccessMessage"] = "Book details saved successfully";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to save book details";
                    }
                    return RedirectToAction("GetDetails");
                }
                return View(book);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }


        public ActionResult EditDetails(int? id)
        {
            var book = bookRepository.GetAllBooks().FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost]
        public ActionResult EditDetails(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bookRepository.EditDetails(book);
                    return RedirectToAction("GetDetails");
                }
                return View(book);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteDetails(int id)
        {
            try
            {
                if (bookRepository.DeleteDetails(id))
                {
                    TempData["SuccessMessage"] = "Book details deleted successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Unable to delete book details";
                }
                return RedirectToAction("GetDetails");
            }
            catch
            {
                return View();
            }
        }
    }

}
