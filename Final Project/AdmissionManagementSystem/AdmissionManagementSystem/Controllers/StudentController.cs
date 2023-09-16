using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdmissionManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        /// <summary>
        /// Student home page
        /// </summary>
        /// <returns></returns>
        public ActionResult Home()
        {
            return View();
        }
    }
}