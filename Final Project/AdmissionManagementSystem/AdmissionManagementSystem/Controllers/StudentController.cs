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
        EducationRepository educationRepository = new EducationRepository();    
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
        /// <summary>
        /// Applied courses and their status view
        /// </summary>
        /// <returns></returns>
        public ActionResult AppliedCourses()
        {
            int studentId = (int)Session["StudentID"];
            List<AppliedCourse> appliedCourses = studentRepository.GetAppliedCoursesByStudentId(studentId);
            return View(appliedCourses);
        }
        /// <summary>
        /// Insert education details
        /// </summary>
        /// <returns></returns>
        public ActionResult InsertEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertEducation(EducationDetails education, HttpPostedFileBase image1, HttpPostedFileBase image2, HttpPostedFileBase image3)
        {
            int studentId = (int)Session["StudentID"];
            educationRepository.Insert(education, image1, image2, image3, studentId);
            return RedirectToAction("EducationDetails");
        }
        /// <summary>
        /// View education details
        /// </summary>
        /// <returns></returns>
        public ActionResult EducationDetails()
        {
            int studentId = (int)Session["StudentID"];
            return View(educationRepository.GetEducationDetails(studentId));
        }


        /// <summary>
        /// logout
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Home", "Home");
        }
        private bool IsImage(HttpPostedFileBase Photo)
        {
            if (Photo != null && Photo.ContentLength > 0)
            {
                string[] allowedImageTypes = { "image/jpeg", "image/png", "image/gif" };
                string contentType = Photo.ContentType;

                return allowedImageTypes.Contains(contentType);
            }
            return false;
        }
    }
}