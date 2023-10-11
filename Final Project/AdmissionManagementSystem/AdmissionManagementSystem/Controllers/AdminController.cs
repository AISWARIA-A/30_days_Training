using AdmissionManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdmissionManagementSystem.Models;
using Newtonsoft.Json.Linq;
using static System.Web.Razor.Parser.SyntaxConstants;
using System.Web.Services.Description;
using System.Web.UI.WebControls;

namespace AdmissionManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        StudentRepository studentRepository = new StudentRepository();
        MessageRepository messageRepository = new MessageRepository();
        CourseRepository courseRepository = new CourseRepository();
        AdminRepository adminRepository = new AdminRepository();
        EducationRepository educationRepository = new EducationRepository();
        /// <summary>
        /// Admin home page
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminHome()
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
        /// <summary>
        /// Registered student details page
        /// </summary>
        /// <returns></returns>
        public ActionResult Students() 
        {
            try
            {
                ModelState.Clear();
                return View(studentRepository.GetAllStudents());
            }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        /// <summary>
        /// To get details of a single student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult StudentDetails(int id)
        {
            try
            {
                Student student = studentRepository.GetStudentById(id);
                return View(student);
            }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        /// <summary>
        /// To delete a student account
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            try
            {
                var item = studentRepository.GetStudentById(id);
                return View(item);
            }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                studentRepository.DeleteStudentById(id);
                return RedirectToAction("Students");
            }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        /// <summary>
        /// To get contact us messages
        /// </summary>
        /// <returns></returns>
        public ActionResult Messages()
        {
            try
            {
                ModelState.Clear();
                return View(messageRepository.GetAllMessages());
            }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        /// <summary>
        /// To delete message
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteMessage(int id)
        {
            try
            {
                var messageItem = messageRepository.GetMessageById(id);
                return View(messageItem);
            }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        [HttpPost]
        public ActionResult MessageDeleteConfirm(int id)
        {
            try
            {
                messageRepository.DeleteMessageById(id);
                return RedirectToAction("Messages");
            }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        /// <summary>
        /// To get the list of courses open for registraion
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
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        /// <summary>
        /// Create course page
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateCourse()
        {
            try { return View(); }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }

        [HttpPost]
        public ActionResult CreateCourse(Course course)
        {
            try
            {
                courseRepository.AddCourses(course);
                return RedirectToAction("Courses");
            }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        /// <summary>
        /// To edit a course 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditCourse(int id)
        {
            try { return View(courseRepository.GetAllCourses().Find(course => course.CourseID == id)); }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }

        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            try
            {
                courseRepository.EditCourse(course);
                return RedirectToAction("Courses");
            }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        /// <summary>
        /// Delete Course page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteCourse(int id) 
        {
            try
            {
                var courseItem = courseRepository.GetCourseById(id);
                return View(courseItem);
            }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        [HttpPost]
        public ActionResult CourseDeleteConfirm(int id) 
        {
            try 
            {
                courseRepository.DeleteCourseById(id);
                return RedirectToAction("Courses"); 
            }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        /// <summary>
        /// Add new admin page
        /// </summary>
        /// <returns></returns>
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            try
            {
                adminRepository.AddAdmin(admin);
                return RedirectToAction("AddAdmin");
            }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }

        }
        /// <summary>
        /// Courses page with navigation to applied students
        /// </summary>
        /// <returns></returns>
        public ActionResult AppliedCourses()
        {
            try
            {
                ModelState.Clear();
                return View(courseRepository.GetAllCourses());
            }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        /// <summary>
        /// Students applied in a course
        /// </summary>
        /// <returns></returns>
        public ActionResult AppliedStudents(int id)
        {
            try
            {
                List<AppliedStudent> appliedStudents = courseRepository.GetAppliedStudentsByCourseIDs(id);
                return View(appliedStudents);
            }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        /// <summary>
        /// View details of applied student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult AppliedStudentDetails(int id)
        {
            try
            {
                Student student = studentRepository.GetStudentById(id);
                return View(student);
            }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        /// <summary>
        /// reject an application
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        public ActionResult RejectStudent(int applicationId)
        {
            try
            {
                bool rejectionResult = courseRepository.RejectStudent(applicationId);

                if (rejectionResult)
                {
                    return Json(new { success = true, message = "Student application rejected successfully!" });
                }
                else
                {
                    return Json(new { success = false, message = "Failed to reject student application. Please try again." });
                }
            }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        /// <summary>
        /// accept an application
        /// </summary>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AcceptStudent(int applicationId)
        {
            try
            {
                bool acceptanceResult = courseRepository.AcceptStudent(applicationId);

                if (acceptanceResult)
                {
                    return Json(new { success = true, message = "Student application accepted successfully!" });
                }
                else
                {
                    return Json(new { success = false, message = "Failed to accept student application. Please try again." });
                }
            }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }

        /// <summary>
        /// logout
        /// </summary>
        /// <returns></returns>

        public ActionResult EducationDetails(int studentId)
        {
            try { return View(educationRepository.GetEducationDetails(studentId)); }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Home", "Home");
        }
        /// <summary>
        /// change admin password
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangePassword()
        {
            try { return View(); }
            catch (Exception Obj_Exception)
            {
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
        [HttpPost]
        public ActionResult ChangePassword(Models.ChangePassword changePassword)
        {
            try
            {
                int adminId = (int)Session["AdminID"];

                int result = adminRepository.ChangePassword(adminId, changePassword);
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
                ErrorLogger.Log(Obj_Exception.Message);
                return null;
            }
        }
    }
}