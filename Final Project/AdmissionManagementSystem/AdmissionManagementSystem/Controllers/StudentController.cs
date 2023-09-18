using AdmissionManagementSystem.Models;
using AdmissionManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdmissionManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        StudentRepository studentRepository = new StudentRepository();
        CourseRepository courseRepository = new CourseRepository();
        /// <summary>
        /// Student home page
        /// </summary>
        /// <returns></returns>
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult ProfileDetails()
        {
            int Id = (int)Session["StudentID"];
            Student student = studentRepository.GetStudentById(Id);
            return View(student);
        }
        /// <summary>
        /// Courses open for registration
        /// </summary>
        /// <returns></returns>
        public ActionResult Courses()
        {
            ModelState.Clear();
            return View(courseRepository.GetAllCourses());
        }
        /// <summary>
        /// Apply for a course
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ApplyForCourse(int id)
        {
            int SId = (int)Session["StudentID"];
            bool applicationResult = studentRepository.ApplyCourse(id, SId);

            if (applicationResult)
            {
                TempData["SuccessMessage"] = "Course application successful!";
                return RedirectToAction("Courses");
            }
            else
            {
                TempData["ErrorMessage"] = "Course application failed. Please try again.";
                return RedirectToAction("Courses");
            }
        }

    }
}