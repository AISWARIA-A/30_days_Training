using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdmissionManagementSystem.Models
{
    public class Admin
    {
        public int AdminID { get; set; }

        [Display(Name ="First name")]
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50)]
        [Display(Name ="Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [Display(Name ="Email address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50)]
        [RegularExpression(@"^\w+$", ErrorMessage = "Username can only contain letters, numbers, or underscores.")]
        [Display(Name ="Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}