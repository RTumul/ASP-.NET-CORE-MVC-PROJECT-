﻿using BulckyBooks.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBooks.DataAccess
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base (options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}