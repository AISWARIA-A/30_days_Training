using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Data
{

    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }

}