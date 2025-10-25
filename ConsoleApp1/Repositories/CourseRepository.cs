using homeWork.Entities;
using Entity_Framework.Configurations;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework.Repositories
{
    public class CourseRepository
    {
        private readonly DBContext _db;

        public CourseRepository(DBContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Course course)
        {
            await _db.Courses.AddAsync(course);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveAsync(Course course)
        {
            _db.Courses.Remove(course);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Course course)
        {
            _db.Courses.Update(course);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Course>> GetAllAsync()
        {
            var courses = await _db.Courses.ToListAsync();
            return courses;
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            var course = await _db.Courses.FindAsync(id);
            return course;
        }

        public async Task<Course> GetByNameAsync(string name)
        {
            var course = await _db.Courses.FirstOrDefaultAsync(c => c.Name == name);
            return course;
        }
    }
}
