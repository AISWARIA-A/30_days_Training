using CRUDApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDApp.Models;

namespace CRUDApp.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            BookRepository bookRepo = new BookRepository();
            ModelState.Clear();
            return View(bookRepo.GetAllBooks());
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            BookRepository BookRepo = new BookRepository();
            ModelState.Clear();
            return View(BookRepo.GetAllBooks());
        }

        // GET: Book/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    BookRepository BookRepo = new BookRepository();

                    if (BookRepo.AddBook(book))
                    {
                        ViewBag.Message = "Book details added successfully";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // POST: Book/Create
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            BookRepository BookRepo = new BookRepository();



            return View(BookRepo.GetAllBooks().Find(Book => Book.Id == id));
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Book book)
        {
            try
            {
                // TODO: Add update logic here
                BookRepository BookRepo = new BookRepository();

                BookRepo.UpdateBook(book);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                BookRepository EmpRepo = new BookRepository();
                if (EmpRepo.DeleteBook(id))
                {
                    ViewBag.AlertMsg = "Book details deleted successfully";

                }
                return RedirectToAction("GetAllBookDetails");

            }
            catch
            {
                return View();
            }
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
