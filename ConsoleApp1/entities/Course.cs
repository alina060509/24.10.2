using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork.Entities
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int DurationHours { get; set; }
        public decimal Price { get; set; }

        public ICollection<Teacher> Teachers { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
