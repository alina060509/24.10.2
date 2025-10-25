using homeWork.Entities;
using Entity_Framework.Configurations;
using Entity_Framework.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework.Services
{
    public class StudentServices
    {
        private readonly DBContext _StudentRepository;

        public StudentServices(DBContext db)
        {
            _StudentRepository = db;
        }

        public async Task AddAsync(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            var stu = _StudentRepository.GetByFullNameAsync(student.FirstName, student.LastName, student.Patronymic);

            if (stu != null)
            {
                throw new Exception($"Студент с таким именем {student.FirstName} уже существует");
            }
            await _StudentRepository.AddAsync(student);
        }

        public async Task RemoveAsync(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            var stu = _StudentRepository.GetByFullNameAsync(student.FirstName, student.LastName, student.Patronymic);

            if (stu == null)
            {
                throw new Exception($"Студента с таким именем {student.FirstName} не  существует");
            }

            await _StudentRepository.RemoveAsync(student);
        }

        public async Task UpdateAsync(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            var stu = _StudentRepository.GetByFullNameAsync(student.FirstName, student.LastName, student.Patronymic);

            if (stu != null)
            {
                throw new Exception($"Студент с таким именем {student.FirstName} обновлен");
            }

            await _StudentRepository.UpdateAsync(student);
        }

        public async Task<List<Student>> GetAllAsync()
        {
            var student = await _StudentRepository.ToListAsync();
            return student;
        }


    }
}

   
