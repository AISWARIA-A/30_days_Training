using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationCRUD.Models;
using WebApplicationCRUD.Repository;

namespace WebApplicationCRUD.Controllers
{
    public class HomeController : Controller
    {

        BookRepository bookRepository = new BookRepository();
        public ActionResult GetDetails()
        {
            BookRepository bookRepository = new BookRepository();
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
                // TODO: Add insert logic here
                bool IsInserted = false;
                


                    if (IsInserted)
                    {
                        TempData["SucessMessage"] = "Book details saved sucessfully";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to save book details";
                    }
                
            
                return RedirectToAction("GetDetails");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        public ActionResult EditDetails(int? id)
        {
            BookRepository bookRepository = new BookRepository();
            return View(bookRepository.GetAllBooks().Find(book => book.Id == id));
        }

        [HttpPost]
        public ActionResult EditDetails(int? id ,Book book) 
        {
            try
            {
                BookRepository bookRepository = new BookRepository();
                bookRepository.EditDetails(book);
                return RedirectToAction("GetDetails");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteDetails(int id, Book book) 
        {
            try
            {
                BookRepository bookRepository = new BookRepository();
                if(bookRepository.DeleteDetails(id))
                {
                    ViewBag.AlertMessage("Book details deleted successfully");
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