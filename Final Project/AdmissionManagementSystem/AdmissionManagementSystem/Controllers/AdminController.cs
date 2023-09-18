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
        /// <summary>
        /// Admin home page
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminHome()
        {
            return View();
        }
        /// <summary>
        /// Registered student details page
        /// </summary>
        /// <returns></returns>
        public ActionResult Students() 
        {
            ModelState.Clear();
            return View(studentRepository.GetAllStudents());
        }
        /// <summary>
        /// To get details of a single student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult StudentDetails(int id)
        {
            Student student = studentRepository.GetStudentById(id);
            return View(student);
        }
        /// <summary>
        /// To delete a student account
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            var item = studentRepository.GetStudentById(id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // Perform the deletion
                studentRepository.DeleteStudentById(id);
                return RedirectToAction("Students");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while deleting the item.");
                return View("DeleteStudent", id); 
            }
        }
        /// <summary>
        /// To get contact us messages
        /// </summary>
        /// <returns></returns>
        public ActionResult Messages()
        {
            ModelState.Clear();
            return View(messageRepository.GetAllMessages());
        }
        /// <summary>
        /// To delete message
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteMessage(int id)
        {
            var messageItem = messageRepository.GetMessageById(id);
            return View(messageItem);
        }
        [HttpPost]
        public ActionResult MessageDeleteConfirm(int id)
        {
            try
            {
                messageRepository.DeleteMessageById(id);
                return RedirectToAction("Messages");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occured while deleting the item");
                return View("DeleteMessage", id);
            }
        }
        /// <summary>
        /// To get the list of courses open for registraion
        /// </summary>
        /// <returns></returns>
        public ActionResult Courses()
        {
            ModelState.Clear();
            return View(courseRepository.GetAllCourses());
        }
        /// <summary>
        /// Create course page
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCourse(Course course)
        {
            courseRepository.AddCourses(course);
            return RedirectToAction("Courses");
        }
        /// <summary>
        /// To edit a course 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditCourse(int id)
        {
            return View(courseRepository.GetAllCourses().Find(course => course.CourseID == id));
        }

        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            try
            {
                courseRepository.EditCourse(course);
                return RedirectToAction("Courses");
            }
            catch
            {
                return View();
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
            var courseItem = courseRepository.GetCourseById(id);
            return View(courseItem); 
        }
        [HttpPost]
        public ActionResult CourseDeleteConfirm(int id) 
        {
            try 
            {
                courseRepository.DeleteCourseById(id);
                return RedirectToAction("Courses"); 
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError("", "An error occured while deleting the item");
                return View("DeleteCourse", id); 
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
            adminRepository.AddAdmin(admin);
            return RedirectToAction("AddAdmin");

        }
        /// <summary>
        /// Courses page with navigation to applied students
        /// </summary>
        /// <returns></returns>
        public ActionResult AppliedCourses()
        {
            ModelState.Clear();
            return View(courseRepository.GetAllCourses());
        }
        /// <summary>
        /// Students applied in a course
        /// </summary>
        /// <returns></returns>
        public ActionResult AppliedStudents(int id)
        {
            List<AppliedStudent> appliedStudents = courseRepository.GetAppliedStudentsByCourseID(id);
            return View(appliedStudents);
        }
        /// <summary>
        /// View details of applied student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult AppliedStudentDetails(int id)
        {
            Student student = studentRepository.GetStudentById(id);
            return View(student);
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

    }
}