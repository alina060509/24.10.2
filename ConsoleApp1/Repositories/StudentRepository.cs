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
    public class StudentRepository
    {
        private readonly DBContext _db;

        public StudentRepository(DBContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Student student)
        {
            await _db.Students.AddAsync(student);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveAsync(Student student)
        {
            _db.Students.Remove(student);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _db.Students.Update(student);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllAsync()
        {
            var students = await _db.Students.ToListAsync();
            return students;
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            var student = await _db.Students.FindAsync(id);
            return student;
        }

        public async Task<Teacher> GetByFullNameAsync(string firstname, string lastname, string patronymic)
        {
            var student = await _db.Instructors.FirstOrDefaultAsync(s => s.FirstName == firstname && s.LastName == lastname && s.Patronymic == patronymic);
            return student;
        }
    }
}
