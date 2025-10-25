using homeWork.Entities;
using Entity_Framework.Configurations;
using Entity_Framework.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework.Services
{
    public class CourseServices
    {
        private readonly DBContext _CourseRepository;

        public CourseServices(DBContext db)
        {
            _CourseRepository = db;
        }

        public async Task AddAsync(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            var cou = _CourseRepository.GetByNameAsync(course.Name);

            if (cou != null)
            {
                throw new Exception($"Курс с таким названием {course.Name} уже существует");
            }
            await _CourseRepository.AddAsync(course);
        }

        public async Task RemoveAsync(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            var cou = _CourseRepository.GetByNameAsync(course.Name);

            if (cou == null)
            {
                throw new Exception($"Курса с таким названием {course.Name} не  существует");
            }

            await _CourseRepository.RemoveAsync(course);
        }

        public async Task UpdateAsync(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            var cou = _CourseRepository.GetByNameAsync(course.Name);

            if (cou != null)
            {
                throw new Exception($"Курс с таким названием {course.Name} обновлен");
            }

            await _CourseRepository.UpdateAsync(course);
        }

        public async Task<List<Course>> GetAllAsync()
        {
            var courses = await _CourseRepository.ToListAsync();
            return courses;
        }

        public async Task<Course> GetByNameAsync(string name)
        {
            var course = await _CourseRepository.Courses.FirstOrDefaultAsync(c => c.Name == name);
            return course;
        }

    }
}

