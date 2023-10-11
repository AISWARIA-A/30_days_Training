using AdmissionManagementSystem.Models;
using AdmissionManagementSystem.Repository;
using GSF.ErrorManagement;
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
            try { return View(); }
            catch (Exception Obj_Exception)
            {
                Models.ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        /// <summary>
        /// To get profile details
        /// </summary>
        /// <returns></returns>
        public ActionResult ProfileDetails()
        {
            try
            {
                int Id = (int)Session["StudentID"];
                Student student = studentRepository.GetStudentById(Id);
                return View(student);
            }
            catch (Exception Obj_Exception)
            {
                Models.ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        /// <summary>
        /// To update profile details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit()
        {
            try
            {
                int studentId = (int)Session["StudentID"];
                var student = studentRepository.GetStudentById(studentId);
                return View(student);
            }
            catch (Exception Obj_Exception)
            {
                TempData["ErrorMessage"] = "An error occurred while loading student data.";
                Models.ErrorLogger.Log(Obj_Exception.Message);
                return RedirectToAction("ProfileDetails");
            }
        }

        /// <summary>
        /// Edit profile
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            try
            {
                int studentId = (int)Session["StudentID"];
                if (ModelState.IsValid)
                {
                    int updateResult = studentRepository.UpdateUser(student, studentId);

                    if (updateResult == 1)
                    {
                        return RedirectToAction("ProfileDetails");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Failed to update student information. Please try again.";
                        return RedirectToAction("Edit");
                    }
                }
                else
                    {
                        TempData["ErrorMessage"] = "Failed to update student information. Please try again.";
                        return RedirectToAction("Edit");
                    }
            }
            catch (Exception Obj_Exception)
            {
                TempData["ErrorMessage"] = "An error occurred while updating student information.";
                Models.ErrorLogger.Log(Obj_Exception.Message);
                return View("ProfileDetails"); 
            }
        }


    /// <summary>
    /// Courses open for registration
    /// </summary>
    /// <returns></returns>
    public ActionResult Courses()
        {
            try
            {
                ModelState.Clear();
                return View(courseRepository.GetAllCourses());
            }
            catch (Exception Obj_Exception)
            {
                Models.ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        /// <summary>
        /// Apply for a course
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ApplyForCourse(int id)
        {
            try
            {
                int SId = (int)Session["StudentID"];
                bool applicationResult = studentRepository.ApplyCourse(id, SId);

                if (applicationResult)
                {
                    TempData["SuccessMessage"] = "Course application successful!";
                    return RedirectToAction("AppliedCourses");
                }
                else
                {
                    TempData["ErrorMessage"] = "Course application failed. Please try again.";
                    return RedirectToAction("AppliedCourses");
                }
            }
            catch (Exception Obj_Exception)
            {
                Models.ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        /// <summary>
        /// Applied courses and their status view
        /// </summary>
        /// <returns></returns>
        public ActionResult AppliedCourses()
        {
            try
            {
                int studentId = (int)Session["StudentID"];
                List<AppliedCourse> appliedCourses = studentRepository.GetAppliedCoursesByStudentId(studentId);
                return View(appliedCourses);
            }
            catch (Exception Obj_Exception)
            {
                Models.ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        /// <summary>
        /// Insert education details
        /// </summary>
        /// <returns></returns>
        public ActionResult InsertEducation()
        {
            try { return View(); }
            catch (Exception Obj_Exception)
            {
                Models.ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        [HttpPost]
        public ActionResult InsertEducation(EducationDetails education, HttpPostedFileBase image1, HttpPostedFileBase image2, HttpPostedFileBase image3)
        {
            try
            {
                int studentId = (int)Session["StudentID"];
                educationRepository.Insert(education, image1, image2, image3, studentId);
                return RedirectToAction("EducationDetails");
            }
            catch (Exception Obj_Exception)
            {
                Models.ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        /// <summary>
        /// View education details
        /// </summary>
        /// <returns></returns>
        public ActionResult EducationDetails()
        {
            try
            {
                int studentId = (int)Session["StudentID"];
                return View(educationRepository.GetEducationDetails(studentId));
            }
            catch (Exception Obj_Exception)
            {
                Models.ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
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
        /// <summary>
        /// To change password
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public ActionResult ChangePassword()
        {
            try { return View(); }
            catch (Exception Obj_Exception)
            {
                Models.ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePassword changePassword)
        {
            try
            {
                int studentId = (int)Session["StudentID"];

                int result = studentRepository.ChangePassword(studentId, changePassword);
                if (result == 1)
                {
                    ViewBag.ErrorMessage = "Password updated successfully!!";
                }
                else
                {
                    ViewBag.ErrorMessage = "Failed to change password. Please check your old password.";
                }

                return View("ChangePassword");
            }
            catch (Exception Obj_Exception)
            {
                Models.ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
    }
}