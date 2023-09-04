using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDWebApplication.Views
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(255, ErrorMessage = "Title cannot exceed 255 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        [StringLength(255, ErrorMessage = "Author cannot exceed 255 characters.")]
        public string Author { get; set; }

        [StringLength(50, ErrorMessage = "Genre cannot exceed 50 characters.")]
        public string Genre { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        // Use byte[] to store image data as binary in the database
        public byte[] CoverImage { get; set; }

    }
}