using System;
using Microsoft.EntityFrameworkCore;
using Plural1.Entities;

namespace Plural1.Context
{
    public class CourseLibraryContext : DbContext
    {
        public CourseLibraryContext(DbContextOptions<CourseLibraryContext> options):base(options)
        {
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author()
                {
                    FirstName = "Diego",
                    Id = Guid.NewGuid(),
                    LastName="Felix",
                    MainCategory="Maincategory",
                    DateOfBirth= DateTimeOffset.Now
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
