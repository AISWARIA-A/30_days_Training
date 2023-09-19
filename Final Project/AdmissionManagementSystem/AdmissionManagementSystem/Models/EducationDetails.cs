using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdmissionManagementSystem.Models
{

    public class EducationDetails
    {
        public int EducationID { get; set; }

        [Required]
        [DisplayName("Student ID")]
        public int StudentID { get; set; }

        [Required]
        [DisplayName("10th school")]
        public string TenthSchool { get; set; }

        [Required]
        [DisplayName("10th CGPA")]
        public decimal TenthCGPA { get; set; }

        [DisplayName("10th certificate")]
        public byte[] TenthCertificate { get; set; }

        [Required]
        [DisplayName("Plus two school")]
        public string PlusTwoSchool { get; set; }

        [Required]
        [DisplayName("Plus two CGPA")]
        public decimal PlusTwoCGPA { get; set; }

        [DisplayName("Plus two Certificate")]
        public byte[] PlusTwoCertificate { get; set; }

        [DisplayName("Degree college")]
        public string DegreeCollege { get; set; }

        [DisplayName("Degree CGPA")]
        public decimal? DegreeCGPA { get; set; }

        [DisplayName("Degree stream")]
        public string DegreeStream { get; set; }

        [DisplayName("Degree certificate")]
        public byte[] DegreeCertificate { get; set; }
    }

}
