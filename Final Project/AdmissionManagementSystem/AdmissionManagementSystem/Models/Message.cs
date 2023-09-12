using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdmissionManagementSystem.Models
{
    public class Message
    {
        public int MessageID { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [DisplayName("Subject")]
        public string Subject { get; set; }

        [DisplayName("Message")]
        [Required(ErrorMessage = "Message is required.")]
        public string MessageText { get; set; }

        public DateTime DateTime { get; set; }
    }
}