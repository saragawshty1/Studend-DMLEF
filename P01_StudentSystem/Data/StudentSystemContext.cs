using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data
{
    internal class StudentSystemContext:DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> studentCourses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DBStudent;Integrated Security=True;TrustServerCertificate=True");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(s => s.Name)
                .HasMaxLength(100);
            modelBuilder.Entity<Student>()
                .Property(s => s.Name)
                .IsUnicode(true);
            modelBuilder.Entity<Student>()
               .Property(s => s.PhoneNumber)
               .IsUnicode(false);
            modelBuilder.Entity<Student>()
                .Property(s => s.PhoneNumber)
                .HasMaxLength(10);
            modelBuilder.Entity<Student>()
                .Property(s => s.PhoneNumber)
                .IsRequired(false);
            modelBuilder.Entity<Student>()
               .Property(s => s.Birthday)
               .IsRequired(false);
            //--------------------------------------
            modelBuilder.Entity<Course>()
               .Property(c => c.Name)
               .HasMaxLength(80);
            modelBuilder.Entity<Course>()
              .Property(c => c.Name)
              .IsUnicode(true);
            modelBuilder.Entity<Course>()
              .Property(c => c.Description)
              .IsUnicode(true);
            modelBuilder.Entity<Course>()
             .Property(c => c.Description)
             .IsRequired(false);
            //***************************
            modelBuilder.Entity<Resource>()
             .Property(r => r.Name)
             .IsUnicode(true);
            modelBuilder.Entity<Resource>()
             .Property(r => r.Name)
             .HasMaxLength(50);
            modelBuilder.Entity<Resource>()
             .Property(r => r.Url)
             .IsUnicode(false);

            //--------------------------
            modelBuilder.Entity<Homework>()
             .Property(h => h.Content)
             .IsUnicode(false);


    modelBuilder.Entity<Student>().HasData
(new Student { StudentId = 1, Name = "sara", PhoneNumber = "011144", RegisteredOn = new DateTime(2024, 7, 20), Birthday=new DateTime(2000,3,5) });
    modelBuilder.Entity<Student>().HasData
            (new Student { StudentId = 2, Name = "malak", PhoneNumber = "013144", RegisteredOn = new DateTime(2024, 7, 21), Birthday = new DateTime(2000, 4, 5) });
   modelBuilder.Entity<Student>().HasData
            (new Student { StudentId = 3, Name = "ali", PhoneNumber = "012244", RegisteredOn = new DateTime(2024, 7, 22), Birthday = new DateTime(2000, 2, 5) });
            //-------------------------------
     modelBuilder.Entity<Course>().HasData
        (new Course { CourseId = 1, Name = "database", Description = "fornewinfo", StartDate = new DateTime(2024, 7, 20), endDate = new DateTime(2024, 9, 20) ,price=3000});
     modelBuilder.Entity<Course>().HasData
        (new Course { CourseId = 2, Name = "OR", Description = "fornewinfo", StartDate = new DateTime(2024, 7, 20), endDate = new DateTime(2024, 10, 20), price = 2000 });

       modelBuilder.Entity<Course>().HasData
        (new Course { CourseId = 3, Name = "logic", Description = "fornewinfo", StartDate = new DateTime(2024, 7, 20), endDate = new DateTime(2024, 8, 20), price = 1000 });
            //------------------------------------------
            modelBuilder.Entity<Resource>().HasData
                    (new Resource { ResourceId = 1, Name = "google", Url="sara@gmail",ResourceType = ResourceType.Video, CourseId = 1 });
            modelBuilder.Entity<Resource>().HasData
                               (new Resource { ResourceId = 2, Name = "mozila", Url = "mm@gmail", ResourceType = ResourceType.Document, CourseId = 2 });
            modelBuilder.Entity<Resource>().HasData
                   (new Resource { ResourceId = 3, Name = "google", Url = "sa@gmail", ResourceType = ResourceType.Presentation, CourseId = 3 });
            //---------------------------------------------------------------------
            modelBuilder.Entity<Homework>().HasData
                   (new Homework { HomeworkId = 1, Content = "d/google/file", ContentType=ContentType.Application , SubmissionTime =new DateTime(2024,8,12),CourseId = 1,StudentId=1 });
            modelBuilder.Entity<Homework>().HasData
                  (new Homework { HomeworkId = 2, Content = "d/mos/file", ContentType = ContentType.pdf, SubmissionTime = new DateTime(2024, 9, 12), CourseId = 2, StudentId = 2 });

        }
    }
}
