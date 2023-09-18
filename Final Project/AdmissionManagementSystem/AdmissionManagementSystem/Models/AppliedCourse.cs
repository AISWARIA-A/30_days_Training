using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AdmissionManagementSystem.Models
{
    public class AppliedCourse
    {
        [DisplayName("Application id")]
        public int ApplicationID { get; set; }
        [DisplayName("Course name")]
        public string CourseName { get; set; }
        [DisplayName("Date of application")]
        public DateTime ApplicationDate { get; set; }
        [DisplayName("Status")]
        public string Status { get; set; }
    }
}