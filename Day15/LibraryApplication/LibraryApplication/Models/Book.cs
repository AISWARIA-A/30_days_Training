using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LibraryApplication.Models
{
    public class Book
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string Pages { get; set; }
    }
}