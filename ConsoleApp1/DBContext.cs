using Entity_Framework.Configurations;
using homeWork.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework
{
    public class DBContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public object Teachers { get; internal set; }

        private readonly string _connectionString = "Server=myServerAddress;Database=RestaurantDb;Trusted_Connection=True;TrustServerCertificate=True;";
        internal object teachers;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
        }

        internal object GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        internal async Task RemoveAsync(Course course)
        {
            throw new NotImplementedException();
        }

        internal async Task UpdateAsync(Course course)
        {
            throw new NotImplementedException();
        }

        internal async Task<List<Course>> ToListAsync()
        {
            throw new NotImplementedException();
        }

        internal object GetByFullNameAsync(string firstName, string lastName, string patronymic)
        {
            throw new NotImplementedException();
        }

        internal async Task RemoveAsync(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        internal async Task UpdateAsync(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        internal async Task RemoveAsync(Student student)
        {
            throw new NotImplementedException();
        }

        internal async Task UpdateAsync(Student student)
        {
            throw new NotImplementedException();
        }

        internal object GetByRatingAsync(int rating)
        {
            throw new NotImplementedException();
        }

        internal async Task RemoveAsync(Review review)
        {
            throw new NotImplementedException();
        }

        internal async Task UpdateAsync(Review review)
        {
            throw new NotImplementedException();
        }

        internal async Task<List<Review>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
