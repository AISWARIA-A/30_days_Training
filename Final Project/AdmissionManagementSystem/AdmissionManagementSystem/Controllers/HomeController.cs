using AdmissionManagementSystem.Models;
using AdmissionManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdmissionManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        MessageRepository messageRepository = new MessageRepository();
        StudentRepository studentRepository = new StudentRepository();
        AdminRepository adminRepository = new AdminRepository();
        LoginRepository loginRepository = new LoginRepository();
        /// <summary>
        /// Home page
        /// </summary>
        /// <returns></returns>
        public ActionResult Home()
        {
            try { return View(); }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        /// <summary>
        /// About us page
        /// </summary>
        /// <returns></returns>
        public ActionResult AboutUs()
        {
            try { return View(); }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        /// <summary>
        /// Contact us page
        /// </summary>
        /// <returns></returns>
        public ActionResult ContactUs()
        {
            try
            {
                return View();
            }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }

        [HttpPost]
        public ActionResult ContactUs(Message message)
        {
            try
            {
                messageRepository.AddMessages(message);
                return RedirectToAction("ContactUs");
            }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        /// <summary>
        /// Registraion page for students
        /// </summary>
        /// <returns></returns>
        public ActionResult Student()
        {
            try { return View(); }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }

        [HttpPost]
        public ActionResult Student(Student student)
        {
            try
            {
                studentRepository.AddStudent(student);
                return RedirectToAction("Login");
            }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        /// <summary>
        /// Login page for admin and student
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            try { return View(); }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int adminId = loginRepository.AuthenticateAdmin(login);

                    if (adminId > 0)
                    {
                        Session["AdminID"] = adminId;
                        Session["Username"] = login.Username.ToString();
                        return RedirectToAction("AdminHome", "Admin");
                    }

                    int studentId = loginRepository.AuthenticateStudent(login);

                    if (studentId > 0)
                    {
                        Session["StudentID"] = studentId;
                        Session["Username"] = login.Username.ToString();
                        return RedirectToAction("Home", "Student");
                    }

                    ViewBag.ErrorMessage = "Invalid username or password";
                }


                return View("Login");
            }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }

        public ActionResult Index()
        {
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