using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AdmissionManagementSystem.Models
{
    public class StudentCourseApplications
    {
        [DisplayName("Application Id")]
        public int ApplicationID { get; set; }

        [DisplayName("Student Id")]
        public int StudentID { get; set; }

        [DisplayName("Course Id")]
        public int CourseID { get; set; }

        [DisplayName("Application date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime ApplicationDate { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; }
    }
}