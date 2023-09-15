using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdmissionManagementSystem.Models
{
    public class Course
    {
        public int CourseID { get; set; }

        [Display(Name ="Course name")]
        [Required(ErrorMessage = "Course name is required.")]
        [StringLength(255, ErrorMessage = "Course name must not exceed 255 characters.")]
        public string CourseName { get; set; }

        [Display(Name ="Description")]
        [StringLength(int.MaxValue, ErrorMessage = "Course description is too long.")]
        public string CourseDescription { get; set; }

        [Display(Name ="Application open from")]
        [Required(ErrorMessage = "Form open date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FormOpenDate { get; set; }

        [Display(Name ="Application closes on")]
        [Required(ErrorMessage = "Form close date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FormCloseDate { get; set; }

        [Display(Name ="No of seats")]
        [Required(ErrorMessage = "Course capacity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Course capacity must be a positive number.")]
        public int CourseCapacity { get; set; }

        [Display(Name ="Status")]
        [Required(ErrorMessage = "Course status is required.")]
        [StringLength(50, ErrorMessage = "Course status must not exceed 50 characters.")]
        public string CourseStatus { get; set; }
    }
}