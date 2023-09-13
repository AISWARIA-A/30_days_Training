﻿using AdmissionManagementSystem.Models;
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

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            try
            {
                return View();
            }
            catch (Exception Obj_Exception)
            {
                return null;
            }
        }

        [HttpPost]
        public ActionResult ContactUs(Message message)
        {
            messageRepository.AddMessages(message);
            return RedirectToAction("Home");
        }

        public ActionResult Student()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Student(Student student)
        {
            studentRepository.AddStudent(student);
            return RedirectToAction("Home");
        }

        public ActionResult Admin() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Admin(Admin admin)
        {
            adminRepository.AddAdmin(admin);
            return RedirectToAction("Home");

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                int adminId = loginRepository.AuthenticateAdmin(login);

                if (adminId > 0)
                {
                    Session["AdminID"] = adminId;
                    return RedirectToAction("Home");
                }

                int studentId = loginRepository.AuthenticateStudent(login);

                if (studentId > 0)
                {
                    Session["StudentID"] = studentId;
                    return RedirectToAction("Home");
                }

                ViewBag.ErrorMessage = "Invalid username or password";
            }

            
            return View("Login");
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