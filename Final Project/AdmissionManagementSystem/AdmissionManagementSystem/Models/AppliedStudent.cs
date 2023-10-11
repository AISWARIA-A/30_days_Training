using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AdmissionManagementSystem.Models
{
    public class AppliedStudent
    {
        [DisplayName("Application id")]
        public int ApplicationID { get; set; }

        [DisplayName("Student name")]
        public string StudentName { get; set; }

        [DisplayName("Application date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime ApplicationDate { get; set; }
        [DisplayName("Application Status")]
        public string Status { get; set; }

        [DisplayName("Student ID")]
        public int StudentID { get; set; }

        public int SeatsLeft { get; set; }
    }
}