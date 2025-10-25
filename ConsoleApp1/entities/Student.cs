using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork.Entities
{
    public class Student
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public string Email { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
