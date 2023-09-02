using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryApplication.Models;

namespace LibraryApplication.Controllers
{
    public class HomeController : Controller
    {
        Services services = new Services();
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add(Book book)
        {
            services.Add(book);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}