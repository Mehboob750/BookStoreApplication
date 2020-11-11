using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<UserModel> UserRegistrations { get; set; }

        public DbSet<BookModel> BookDetails { get; set; }
    }
}
