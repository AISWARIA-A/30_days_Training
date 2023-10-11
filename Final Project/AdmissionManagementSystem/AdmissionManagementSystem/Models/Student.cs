using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdmissionManagementSystem.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        [DisplayName("First name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name should only contain letters.")]
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name must be between 1 and 50 characters.", MinimumLength = 1)]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        [Required(ErrorMessage = "Last name is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name should only contain letters.")]
        [StringLength(50, ErrorMessage = "Last name must be between 1 and 50 characters.", MinimumLength = 1)]
        public string LastName { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Gender")]
        [StringLength(10)]
        public string Gender { get; set; }

        [Display(Name = "Phone number")]
        [StringLength(15, ErrorMessage = "Phone number must be up to 15 characters.")]
        public string PhoneNumber { get; set; }

        [DisplayName("E-mail address")]
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(100, ErrorMessage = "Email address must be up to 100 characters.")]
        public string EmailAddress { get; set; }

        [DisplayName("Address")]
        [StringLength(255, ErrorMessage = "Address must be up to 255 characters.")]
        public string Address { get; set; }

        [DisplayName("State")]
        [StringLength(50, ErrorMessage = "State must be up to 50 characters.")]
        public string State { get; set; }

        [DisplayName("City")]
        [StringLength(50, ErrorMessage = "City must be up to 50 characters.")]
        public string City { get; set; }

        [DisplayName("Username")]
        [StringLength(50, ErrorMessage = "Username must be between 1 and 50 characters.", MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Only letters and numbers are allowed in the username.")]
        public string Username { get; set; }

        [DisplayName("Password")]
        [StringLength(255, ErrorMessage = "Password must be at least 6 characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
