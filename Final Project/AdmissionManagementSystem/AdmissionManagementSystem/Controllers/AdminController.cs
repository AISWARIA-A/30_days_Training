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
    }
}