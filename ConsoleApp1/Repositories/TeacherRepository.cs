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
    public class TeacherRepository
    {
        private readonly DBContext _db;

        public TeacherRepository(DBContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Teacher teacher)
        {
            await _db.Teacher.AddAsync(teacher);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveAsync(Teacher teacher)
        {
            _db.Teacher.Remove(teacher);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Teacher teacher)
        {
            _db.Teacher.Update(teacher);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            var teachers = await _db.Teacher.ToListAsync();
            return teachers;
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            var teacher = await _db.Teacher.FindAsync(id);
            return teacher;
        }

        public async Task<Teacher> GetByFullNameAsync(string firstname, string lastname, string patronymic)
        {
            var teacher = await _db.Teacher.FirstOrDefaultAsync(i => i.FirstName == firstname && i.LastName == lastname && i.Patronymic == patronymic);
            return teacher;
        }
    }
}