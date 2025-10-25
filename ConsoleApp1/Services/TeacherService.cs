using Entity_Framework.Configurations;
using homeWork.Entities;
using Entity_Framework.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework.Services
{
    public class TeacherServices
    {
        private readonly DBContext _TeacherRepository;

        public TeacherServices(DBContext db)
        {
            _TeacherRepository = db;
        }

        public async Task AddAsync(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }

            var teach = _TeacherRepository.GetByFullNameAsync(teacher.FirstName, teacher.LastName, teacher.Patronymic);

            if (teach != null)
            {
                throw new Exception($"Преподаватель с таким именем {teacher.FirstName} уже существует");
            }
            await _TeacherRepository.AddAsync(teacher);
        }

        public async Task RemoveAsync(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }

            var teach = _TeacherRepository.GetByFullNameAsync(teacher.FirstName, teacher.LastName, teacher.Patronymic);

            if (teach == null)
            {
                throw new Exception($"Преподавателя с таким именем {teacher.FirstName} не  существует");
            }

            await _TeacherRepository.RemoveAsync(teacher);
        }

        public async Task UpdateAsync(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }

             var teach = _TeacherRepository.GetByFullNameAsync(teacher.FirstName, teacher.LastName, teacher.Patronymic);

            if (teach != null)
            {
                throw new Exception($"Преподаватель с таким именем {teacher.FirstName} обновлен");
            }

            await _TeacherRepository.UpdateAsync(teacher);
        }

        public async Task<List<Teacher>> GetAllAsync(List<Teacher> teachers)
        {
            var teacher = await _TeacherRepository.ToListAsync();
            return teachers;
        }

        public async Task<Teacher> GetByNameAsync(string lastname)
        {
            var teacher = await _TeacherRepository.Teacher.FirstOrDefaultAsync(c => c.LastName == lastname);
            return teacher;
        }

        internal async Task GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}

