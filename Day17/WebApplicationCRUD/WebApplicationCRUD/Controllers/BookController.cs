using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationCRUD.Models;

namespace WebApplicationCRUD.Controllers
{
    public class BookController : Controller
    {
        LIBRARYEntities db = new LIBRARYEntities();
        // GET: Book
        public ActionResult Index()
        {
            return View(db.Libraries.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, Library library)
        {
            string filename = Path.GetFileName(file.FileName);
            string _filename = DateTime.Now.ToString("yymmssff") + filename;
            string extension = Path.GetExtension(file.FileName);
            string path = Path.Combine(Server.MapPath("~/Images/"), _filename);
            library.Cover = "~/Images/" + _filename;

            if(extension.ToLower()== ".jpeg" || extension.ToLower()== ".jpg" || extension.ToLower() == ".png")
            {
                if(file.ContentLength <= 1000000)
                {
                    db.Libraries.Add(library);
                    if (db.SaveChanges()> 0)
                    {
                        file.SaveAs(path);
                        ViewBag.msg = "Record Added";
                        ModelState.Clear();
                    }
                }
                else
                {
                    ViewBag.msg = "Size is not valid";
                }
            }
            return View();
        }
    }
}